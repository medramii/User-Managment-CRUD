import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
 
const routes: Routes = [
  {
    path: 'users/home',
    component: HomeComponent,
  },
  {
    path: 'users/create',
    component: CreateComponent,
  },
  {
    path:'users/edit/:id',
    component: EditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
