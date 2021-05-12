import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { ApiCollectionResponse } from '../admin-panel/Models/apiResponse';
import { NewsModel } from '../manager-panel/Models/NewsModel';
import { NewsManagerService } from '../manager-panel/Services/news-manager.service';
import { ApiResponse } from '../Models/api.response';

@Component({
  selector: 'app-manager-panel',
  templateUrl: './manager-panel.component.html',
  styleUrls: ['./manager-panel.component.css']
})
export class ManagerPanelComponent implements OnInit {

  model = new NewsModel();
  errorMessage!: string;
  allAnimes: Array<NewsModel>;

  constructor(
    private managerService: NewsManagerService,
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
        this.managerService.addNews(this.model).subscribe((data: ApiResponse) => {
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
  
        // setTimeout(() => {
        //   /** spinner ends after 5 seconds */
        //   this.spinner.hide();
        //   this.notifier.notify('success', 'Success add new event!');
        // }, 5000);
        form.resetForm();
      }
    }

  ngOnInit() {
    this.managerService.getAllNews().subscribe((res: ApiCollectionResponse)=>{
      if(res.isSuccessful){
        console.log(res.data)
        this.allAnimes = res.data
      }
    })
  }

}
