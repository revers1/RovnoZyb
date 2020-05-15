import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/core/api.service';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { AnketasModel } from './Models/anketas.model';
import { AnketasService } from './Services/anketas.service';

@Component({
  selector: 'app-anketas',
  templateUrl: './anketas.component.html',
  styleUrls: ['./anketas.component.css']
})
export class AnketasComponent implements OnInit {

  model = new AnketasModel();
  isError: boolean;
  message: string;

  constructor(private anketasService: AnketasService,
    private notifier: NotifierService,
    private spinner: NgxSpinnerService,
    private router: Router) { }

  ngOnInit() {
    this.isError = false;
  }
  OnSubmit() {

    this.spinner.show();

    if (this.model.FullName === null) {
      this.notifier.notify('error', 'Заполните поле *Имя');
      this.isError = true;
    }

    if (this.model.Phone === null) {
      this.notifier.notify('error', 'Заполните поле *Телефон');
      this.isError = true;
    }

    if (this.isError === false) {

      this.anketasService.addAnketas(this.model).subscribe(
        data => {

          if (data.status === 200) {
            //vse ok
            this.notifier.notify('success', 'Заявка отправлена, ожидайте звонка');
            
            this.message = 'Заявка отправлена, ожидайте звонка';

            setTimeout(() => {
              this.router.navigate(['/']);

            }, 3000);


            this.spinner.hide();

          }
          else {

            for (let i = 0; i < data.errors.length; i++) {
              this.notifier.notify('error', data.errors[i]);
            }


            console.log(data);
            this.spinner.hide();
          }


        }
      );

    }
    else {
      this.isError = false;
      this.spinner.hide();
    }

  }
}
