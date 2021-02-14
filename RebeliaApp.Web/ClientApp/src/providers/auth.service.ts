import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router, CanActivate } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserLoginRequest } from "../model/Request/index";
import { UserLoginResponse } from "../model/Response/index";



@Injectable()
export class AuthService implements CanActivate {
  private baseUrl: string = 'https://localhost:5001/'

  constructor(public router: Router, public jwtHelper: JwtHelperService, private http: HttpClient) { }

  LoginToUserAccount(request: UserLoginRequest): Observable<UserLoginResponse> {
    return this.http.post<UserLoginResponse>(this.baseUrl + 'Api/AuthEndpoint/Login', request);
  }


  canActivate(): boolean {
    const token = localStorage.getItem('userToken');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(['login']);
    return true;
  }
}