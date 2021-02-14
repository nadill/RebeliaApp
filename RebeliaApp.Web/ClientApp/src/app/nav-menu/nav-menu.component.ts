import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../providers/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(private router: Router, private auth: AuthService) {
    this.isUserAuth = auth.canActivate();
  }

  isUserAuth: boolean = false;


  public Logout() {
    localStorage.removeItem("userToken");
    this.router.navigateByUrl("login")
  }
}
