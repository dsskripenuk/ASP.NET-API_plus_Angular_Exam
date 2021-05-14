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
        }, 5000);
      } 
      else 
      {
        this.adminService.addAnime(this.model).subscribe((data: ApiResponse) => {
            if (data.code == 200) {
              this.spinner.hide();
              this.notifier.notify('success', 'User added!');
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

  ngOnInit() {
    this.adminService.getAllAnimes().subscribe((res: ApiCollectionResponse)=>{
      if(res.isSuccessful){
        console.log(res.data)
        this.allAnimes = res.data
      }
    })
  }
}
