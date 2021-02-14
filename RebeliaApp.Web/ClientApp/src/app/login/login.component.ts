import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../providers/account.service';
import { UserLoginRequest } from '../../model/Request/index';
import { UserLoginResponse } from '../../model/Response/index';
import { UserAccount } from '../../model/Shared/UserAccount';
import { ResponseCode } from '../../model/Shared/Enums';
import { Route, Router } from '@angular/router';
import { AuthService } from '../../providers/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})

export class LoginComponent implements OnInit {

  public loginCredentials: UserLoginRequest = { email: '', password: '' };
  formValid: boolean = true;

  constructor(private router: Router, private authService: AuthService) {
  }

  ngOnInit() {
  }

  Login(): void {
    let userResponse = this.authService.LoginToUserAccount(this.loginCredentials).subscribe(result => {
      if (result.responseCode == ResponseCode.SUCCESS) {
        localStorage.setItem("userToken", result.tokenString);
        this.router.navigateByUrl("/");
        this.formValid = true;
        return result;
      } else {
        this.formValid = false;
        return null;
      }
    });
    //console.log(localStorage.getItem("LoggedUser"))
  }

}