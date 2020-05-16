import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResult } from 'src/app/Models/result.model';
import { RegisterModel } from 'src/app/Models/register.model';
import { UserItem } from '../Models/user-item.model';

@Injectable({
    providedIn: 'root'
})
export class UserManagerService {

    baseUrl = '/api/UserManager';
    baseUrl2 = '/api/Anketa';

constructor(private http: HttpClient) { }


    getAllUsers () {
        return this.http.get(this.baseUrl);
    }

  


    removeUser(id: string)
    {
        return this.http.post(this.baseUrl + '/RemoveUser/' + id, id);
    }

    // editUser(id: string, model: UserItem): Observable<ApiResult>{
    //     return this.http.post(this.baseUrl + '/editUser/' + id, id);
    // }
    editUser(id: string, model: UserItem){
        return this.http.post(this.baseUrl + '/editUser/' + id, id);
    }
    getUserById(id: string) {
        return this.http.get(this.baseUrl + '/' + id);
      }
      
}
