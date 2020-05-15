import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponentComponent } from './NotFoundComponent/NotFoundComponent.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { NotifierModule,NotifierOptions } from 'angular-notifier';
import { NgxSpinnerModule } from "ngx-spinner";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminAreaComponent } from './Areas/admin-area/admin-area.component';
import { UserAreaComponent } from './Areas/user-area/user-area.component';
import { DashboardsComponent } from './Areas/admin-area/Components/dashboard/dashboards.component';
import { UserManagerComponent } from './Areas/admin-area/Components/user-manager/user-manager.component';
import { AnketasComponent } from './anketas/anketas/anketas.component';
import { PricelistComponent } from './pricelist/pricelist.component';
import { DemoNgZorroAntdModule } from './ng-zorro-antd.module';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
registerLocaleData(en);

import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';

const notifierOptions: NotifierOptions = {
   position: {horizontal: { position: 'right' }, vertical: { position: 'top' }}
 };

 @NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      LoginComponent,
      RegisterComponent,
      RegisterComponent,
      NotFoundComponentComponent,
      AdminAreaComponent,
      UserAreaComponent,
      DashboardsComponent,
      UserManagerComponent,
      AnketasComponent,
      PricelistComponent,
      PricelistComponent
   ],
   imports: [
      BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      NotifierModule.withConfig(notifierOptions),
      BrowserAnimationsModule,
      NgxSpinnerModule,
	   DemoNgZorroAntdModule 
   ],
 
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule{}