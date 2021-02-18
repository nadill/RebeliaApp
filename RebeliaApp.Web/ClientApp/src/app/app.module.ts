import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AddBattleComponent } from './add-battle/add-battle.component';
import { AddInfinityComponent } from './add-battle/infinity/infinity.component';
import { AddWarmachineComponent } from './add-battle/warmachine/warmachine.component';
import { LoginComponent } from './login/login.component';
import { SpinnerComponent } from './components/spinner/spinner.component';

import { log } from 'util';

// Service Providers
import { AccountService } from '../providers/account.service';
import { InfinityService } from '../providers/infinity.service';
import { WarmachineService } from '../providers/warmachine.service';
import { AuthService } from '../providers/auth.service';

export function tokenGetter() {
  return localStorage.getItem("userToken");
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AddBattleComponent,
    AddInfinityComponent,
    AddWarmachineComponent,
    SpinnerComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthService] },
      { path: 'add-battle', component: AddBattleComponent, canActivate: [AuthService]},
      { path: 'add-infinity', component: AddInfinityComponent, canActivate: [AuthService] },
      { path: 'add-warmachine', component: AddWarmachineComponent, canActivate: [AuthService] },

      { path: 'login', component: LoginComponent },
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5001"],
        blacklistedRoutes: []
      }
    })

  ],
  providers: [AccountService, InfinityService, WarmachineService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
