import { Routes } from '@angular/router';
import { Constants } from './constants';

export const routes: Routes = [
  // Authentication and Authorization

  {
    path: Constants.ROUTE_AUTH,
    children: [
      {
        path: '',
        redirectTo: Constants.ROUTE_AUTH_SIGNIN,
        pathMatch: 'full',
      },
      {
        path: Constants.ROUTE_AUTH_SIGNIN,
        data: { title: 'Signin | ' + Constants.TITLE },
        loadComponent: () =>
          import('./pages/auth/signin/signin.component').then(
            (m) => m.SigninComponent
          ),
      },
      {
        path: Constants.ROUTE_AUTH_SIGNUP,
        data: { title: 'Signup | ' + Constants.TITLE },
        loadComponent: () =>
          import('./pages/auth/signup/signup.component').then(
            (m) => m.SignupComponent
          ),
      },
    ],
  },

  // Errors

  {
    path: Constants.ROUTE_NOT_FOUND,
    data: { title: 'Not Found | ' + Constants.TITLE },
    loadComponent: () =>
      import('./pages/errors/not-found/not-found.component').then(
        (m) => m.NotFoundComponent
      ),
  },
  {
    path: Constants.ROUTE_UNAUTHORIZED,
    data: { title: 'Unauthorized | ' + Constants.TITLE },
    loadComponent: () =>
      import('./pages/errors/unauthorized/unauthorized.component').then(
        (m) => m.UnauthorizedComponent
      ),
  },
  {
    path: '**',
    redirectTo: Constants.ROUTE_NOT_FOUND,
    pathMatch: 'full',
  },
];
