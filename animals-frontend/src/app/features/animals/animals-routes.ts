import { Routes } from '@angular/router';
import { AnimalsComponent } from './animals.component';
import { AnimalsEditComponent } from './components/animals-edit/animals-edit.component';

export const routes: Routes = [
  {
    path: '',
    component: AnimalsComponent,
  },
  {
    path: 'edit/:id',
    component: AnimalsEditComponent
  }
];
