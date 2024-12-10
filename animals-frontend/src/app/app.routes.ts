import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./features/animals/animals-routes').then((mod) => mod.routes),
  },
];
