import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AddBattleComponent } from './add-battle/add-battle.component';
import { AddInfinityComponent } from './add-battle/infinity/infinity.component';
import { LoginComponent } from './login/login.component';
import { log } from 'util';

// Service Providers;
import { AccountService } from '../providers/account.service';
import { InfinityService } from '../providers/infinity.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AddBattleComponent,
    AddInfinityComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'add-battle', component: AddBattleComponent },
      { path: 'add-battle/infinity', component: AddInfinityComponent },
      { path: 'login', component: LoginComponent },
    ])

  ],
  providers: [AccountService, InfinityService],
  bootstrap: [AppComponent]
})
export class AppModule { }
