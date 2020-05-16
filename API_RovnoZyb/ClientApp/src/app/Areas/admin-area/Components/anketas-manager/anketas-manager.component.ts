import { Component, OnInit } from '@angular/core';
import { AnketasModel } from 'src/app/anketas/anketas/Models/anketas.model';
import { AnketasService } from '../../../../anketas/anketas/Services/anketas.service';
import { ApiResult } from 'src/app/Models/result.model';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-anketas-manager',
  templateUrl: './anketas-manager.component.html',
  styleUrls: ['./anketas-manager.component.css']
})
export class AnketasManagerComponent implements OnInit {
  
  Anketas: AnketasModel[] = [];
  constructor(private anketaService: AnketasService,
    private notifier: NotifierService) { }

  ngOnInit() {
        this.anketaService.getAllAnketas().subscribe((AllAnketas: AnketasModel[]) => {
       this.Anketas=AllAnketas;
       console.log(this.Anketas);
        
       
    });
  }

  closeAnketas(id: string){
    this.anketaService.closeAnketas(id).subscribe( (data: ApiResult) => {
      if(data.status === 200)
      {
        this.notifier.notify('success', 'Анкета удалена');
       

      }
      else{
        for(var i = 0; i < data.errors; i++)
        {
          this.notifier.notify('error', data.errors[i]);
        }
      }
    
    }
  )

  }

  
  removeAnketas(id: string)
  {
    
    this.anketaService.removeAnketas(id).subscribe(
      (data: ApiResult) => {
        if(data.status === 200)
        {
          this.notifier.notify('success', 'Анкета удалена');
         

        }
        else{
          for(var i = 0; i < data.errors; i++)
          {
            this.notifier.notify('error', data.errors[i]);
          }
        }
      
      }
    )
  }

}
