import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component'
import { from } from 'rxjs';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NotFoundComponentComponent } from './NotFoundComponent/NotFoundComponent.component';
import { AdminAreaComponent } from './Areas/admin-area/admin-area.component';
import { DashboardsComponent } from './Areas/admin-area/Components/dashboard/dashboards.component';
import { UserManagerComponent } from './Areas/admin-area/Components/user-manager/user-manager.component';
import { AdminGuard } from './guards/admin.guard';
import { NotLoginGuard } from './guards/notLogin.guard';
const routes: Routes = [
 {path:'' ,component: HomeComponent, pathMatch:'full'},

 {path:'login',component: LoginComponent, pathMatch:'full',canActivate:[NotLoginGuard]},
 {path:'register',component: RegisterComponent, pathMatch:'full',canActivate:[NotLoginGuard]},

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