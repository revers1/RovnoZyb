import { Component, OnInit } from '@angular/core';
import { RegisterModel } from 'src/app/Models/register.model';
import { Router, ActivatedRoute} from '@angular/router';
import { Params } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserManagerService } from 'src/app/Areas/admin-area/Services/user-manager.service';
import { UserItem } from 'src/app/Areas/admin-area/Models/user-item.model';
import { ApiResult } from 'src/app/Models/result.model';

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.css']
})
export class MyprofileComponent implements OnInit {

  model : UserItem;
  confirmPassword: string;
  isError: boolean;
  userId: string;
 
  constructor(
    private userManagerService: UserManagerService,
    private notifier: NotifierService,
    private spinner: NgxSpinnerService,
    private router: Router,
    private route: ActivatedRoute
 
  ) {
  }

  ngOnInit() {
    this.isError = false;
    // this.spinner.show();

    this.route.params.subscribe((params: Params) => {
      this.userId = params['id'];
    });
    this.userManagerService.getUserById(this.userId).subscribe((prod: UserItem) => {
      this.model = prod;
      // this.spinner.hide();
    });
  }
  OnSubmit() {
    // this.spinner.show();
    if (this.isError === false) {
      // this.spinner.show();
      this.userManagerService.editUser(this.userId, this.model).subscribe(
        (data: ApiResult) => {
          if (data.status === 200) {
            this.notifier.notify('success', 'Данные изменены!');
            this.router.navigate(['/']);
          }
        },
        (error) => {
          this.notifier.notify('error', 'ERROR!!!');
        }
      );
    }
  }
  

}

