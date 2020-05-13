import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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


}
