import { Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { UserAccount } from "../model/Shared/UserAccount";
import { GetAllAccountsResponse } from '../model/Response/GetAllAccountsResponse';
import jwt_decode from "jwt-decode";

@Injectable()
export class AccountService {

  private baseUrl: string = 'https://localhost:5001/'

  constructor(private http: HttpClient) {

  }


  GetUserTokenInfo(): UserAccount {
    let token: string = localStorage.getItem("userToken");
    let tokenData: {
      PlayerID: number,
      FirstName: string,
      LastName: string,
      Nick:string
    } = jwt_decode(token);
    let user: UserAccount = {
      firstName: tokenData.FirstName,
      lastName: tokenData.LastName,
      nick: tokenData.Nick,
      playerID: tokenData.PlayerID
    };
    return user;
  }

  GetAllAccounts(): Observable<GetAllAccountsResponse> {
    let userAccounts = this.http.get(this.baseUrl + 'Api/AccountEndpoint/GetAllAccounts');
    return userAccounts as Observable<GetAllAccountsResponse>;
  }

  GetAllAccountsExceptLoggedUser(): Observable<GetAllAccountsResponse> {
    let userData: UserAccount = this.GetUserTokenInfo();

    let userAccounts = this.http.get(this.baseUrl + 'Api/AccountEndpoint/GetAllAccountsExceptLoggedUser/' + userData.playerID);
    return userAccounts as Observable<GetAllAccountsResponse>;
  }

}
