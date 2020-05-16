import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AnketasModel } from '../Models/anketas.model';
import { ApiResult } from 'src/app/Models/result.model';


@Injectable({
  providedIn: 'root'
})
export class AnketasService {

  baseUrl = '/api/Anketa';




constructor(private http: HttpClient) {

}


getAllAnketas () {
  return this.http.get(this.baseUrl);
}

removeAnketas(id: string)
{
    return this.http.post(this.baseUrl + '/RemoveAnketas/' + id, id);
}
// addAnketas(id: string)
// {
//     return this.http.post(this.baseUrl + '/addAnketas/' + id, id);
// }
addAnketas(AnketaModel: AnketasModel){

  const token = localStorage.getItem('token');

  const jwtToken = token.split('.')[1];
  const decodedJwtJsonData = window.atob(jwtToken);
  const decodedJwtData = JSON.parse(decodedJwtJsonData);

  AnketaModel.id = decodedJwtData.id;
  AnketaModel.isClose=false;
  
  console.log(AnketaModel);//Просто посмотреть

  return this.http.post<ApiResult>('/api/anketa/addanketas', AnketaModel);
}

editAnketas(id: string, AnketaModel: AnketasModel){
  return this.http.post<ApiResult>('/api/anketa/editanketas/' + id, AnketaModel);
}


}
