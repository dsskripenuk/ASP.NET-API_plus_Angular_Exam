import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { ApiResponse } from '../Models/api.response';
import { AnimeModel } from './Models/AnimeModel';
import { ApiCollectionResponse } from './Models/apiResponse';
import { AnimeManagerService } from './Services/anime-admin.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  model = new AnimeModel();
  errorMessage!: string;
  allAnimes: Array<AnimeModel>;

  constructor(
    private adminService: AnimeManagerService,
    private notifier: NotifierService,
    private spinner: NgxSpinnerService) { }

    onSubmit(form: NgForm) {
      this.spinner.show();
      
      if (this.model.isValid() == false) 
      {
        this.notifier.hideAll();
  
        setTimeout(() => {
          this.spinner.hide();
          this.notifier.notify('error', 'Enter all fields!');
        }, 2000);
      } 
      else 
      {
        this.adminService.addAnime(this.model).subscribe((data: ApiResponse) => {
            if (data.code == 200) {
              this.spinner.hide();
              this.notifier.notify('success', 'Anime added!');
            }
          },
          (error) => {
            this.notifier.notify('error', 'Server error');
            this.spinner.hide();
          }
        );
  
        form.resetForm();
      }
    }


    deleteAnime(id: number) {
        this.adminService.removeAnime(id).subscribe(
        (data: ApiResponse) => {
          if (data.code === 200) {
            this.notifier.notify('success', 'Anime removed!');
  
            this.allAnimes = this.allAnimes.filter(t => t.id !== id);
  
          } else {
            for (let i = 0; i < data.errors; i++) {
              this.notifier.notify('error', data.errors[i]);
            }
          }
        }
      );
    }

  ngOnInit():  void {
    this.spinner.show();

    this.adminService.getAllAnimes().subscribe((AllAnimes: AnimeModel[]) => {
      this.allAnimes = AllAnimes;
      this.spinner.hide();
    }
    );
  }
  //  {
  //   this.adminService.getAllAnimes().subscribe((res: ApiCollectionResponse)=>{
  //     if(res.isSuccessful){
  //       console.log(res.data)
  //       this.allAnimes = res.data
  //     }
  //   })
  // }
}
