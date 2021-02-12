import { Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { UserLoginRequest } from "../model/Request/index";
import { UserLoginResponse } from "../model/Response/index";
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AccountService {

  private baseUrl: string = 'https://localhost:5001/'

  constructor(private http: HttpClient) {
  }

  LoginToUserAccount(request: UserLoginRequest): Observable<UserLoginResponse> {
    return this.http.post<UserLoginResponse>(this.baseUrl + 'Api/AuthEndpoint/Login', request);
  }

}
