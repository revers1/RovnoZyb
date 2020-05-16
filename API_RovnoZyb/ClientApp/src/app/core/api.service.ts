import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from './../Models/register.model';
import { ApiResult } from './../Models/result.model';
import { LoginModel } from './../Models/login.model';
import { Observable } from 'rxjs';
import { SignInModel } from '../Areas/admin-area/Models/login.model';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  baseUrl = '/api/Account';
  baseUrl2 = '/api/Anketa';
  loginStatus = new EventEmitter<boolean>();

  
  SignUp(model: RegisterModel): Observable<ApiResult>
  {
      return this.http.post<ApiResult>(this.baseUrl + '/register', model);
      
  }

  SignIn(UserLoginDTO: SignInModel): Observable<ApiResult>{
      return this.http.post<ApiResult>(this.baseUrl + '/login', UserLoginDTO);

  }

  isAdmin() {
      const token = localStorage.getItem('token');
      if(token !== null){
          const jwtToken = token.split('.')[1];
          const decodedJwtJsonData = window.atob(jwtToken);
          const decodedJwtData = JSON.parse(decodedJwtJsonData);
          if(decodedJwtData.roles === 'User'){
              return false;
          }
          else if(decodedJwtData.roles === 'Admin'){
              return true;
          }
      }
      else{
          return false;
      }
  }

  isLoggedIn() {
      const token = localStorage.getItem('token');
      if(token !== null){
          return true;
      }
      else{
          return false;
      }
  }

  Logout() {
      localStorage.removeItem('token');
      this.loginStatus.emit(false);
  }


  getAllAnketas () {
    return this.http.get(this.baseUrl2);
}



}



