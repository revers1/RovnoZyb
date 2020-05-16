import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component'

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NotFoundComponentComponent } from './NotFoundComponent/NotFoundComponent.component';
import { AdminAreaComponent } from './Areas/admin-area/admin-area.component';
import { DashboardsComponent } from './Areas/admin-area/Components/dashboard/dashboards.component';
import { UserManagerComponent } from './Areas/admin-area/Components/user-manager/user-manager.component';
import { AdminGuard } from './guards/admin.guard';
import { NotLoginGuard } from './guards/notLogin.guard';
import { ContactsComponent } from './contacts/contacts/contacts.component';

import { AnketasComponent } from './anketas/anketas/anketas.component';
import { AuthGuard } from './guards/auth.guard';
import { PricelistComponent } from './pricelist/pricelist.component';
import { MyprofileComponent } from 'src/myprofile/myprofile.component';
import { AnketasManagerComponent } from './Areas/admin-area/Components/anketas-manager/anketas-manager.component';

const routes: Routes = [
 {path:'' ,component: HomeComponent, pathMatch:'full'},

 {path:'login',component: LoginComponent, pathMatch:'full',canActivate:[NotLoginGuard]},
 {path:'register',component: RegisterComponent, pathMatch:'full',canActivate:[NotLoginGuard]},
 {path:'anketas',component: AnketasComponent, pathMatch:'full',canActivate:[AuthGuard]},
 {path:'pricelist',component: PricelistComponent, pathMatch:'full'},
 {path:'contacts', component: ContactsComponent, pathMatch: 'full'},
 {path:'profile', component: MyprofileComponent, pathMatch: 'full',canActivate:[AuthGuard]},
 {path:'anketas-list', component:  AnketasManagerComponent, pathMatch: 'full',canActivate:[AdminGuard]},



 {path:'admin-panel',
 component: AdminAreaComponent,
 canActivate: [AdminGuard],
children:[

{path: '', component: DashboardsComponent, pathMatch:'full'},
{path: 'user-manager', component: UserManagerComponent, pathMatch:'full'},


],
 },

 {path: '**' ,component: NotFoundComponentComponent}

];
 
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }