import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClassComponent } from './add-class/add-class.component';
import { EditClassComponent } from './edit-class/edit-class.component';
import { HomeComponent } from './home/home.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { EditStudentComponent } from './edit-student/edit-student.component';


const routes: Routes = [
  {
    path: "",
    component: HomeComponent,
  },
  {
    path: "class/add",
    component: AddClassComponent,
  },
  {
    path: "class/edit/:id",
    component: EditClassComponent,
  },
  {
    path: "student/add",
    component: AddStudentComponent,
  },
  {
    path: "student/edit/:id",
    component: EditStudentComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
