import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AnketasModel } from '../Models/anketas.model';
import { ApiResult } from 'src/app/Models/result.model';

@Injectable({
  providedIn: 'root'
})
export class AnketasService {

  baseUrl = '/api/anketas';




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
  return this.http.post<ApiResult>('/api/anketa/addanketas', AnketaModel);
}

editAnketas(id: string, AnketaModel: AnketasModel){
  return this.http.post<ApiResult>('/api/anketa/editanketas/' + id, AnketaModel);
}

}
