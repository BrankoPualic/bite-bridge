import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map } from 'rxjs';
import {
  IAuthorizationDto,
  ISigninDto,
  ISignupDto,
} from '../_generated/interfaces';
import { AuthController } from '../_generated/services';
import { DateTime } from 'luxon';

interface IUserSource {
  id: string;
  name: string;
  email: string;
  roles: string[];
  token: string;
  tokenExpireDate: Date;
}
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSource = new BehaviorSubject<IUserSource | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private router: Router, private authController: AuthController) {}

  signin(user: ISigninDto) {
    return this.authController.Signin(user).pipe(
      map((result) => {
        if (result) this.setCurrentUser(result);
        return result;
      })
    );
  }

  async signup(user: ISignupDto) {}

  signout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  setCurrentUser(result: IAuthorizationDto) {
    const tokenInfo = this.getDecodedToken(result.token);

    const userSource: IUserSource = {
      id: tokenInfo.nameid,
      roles: [],
      email: tokenInfo.email,
      name: tokenInfo.name,
      token: result.token,
      tokenExpireDate: DateTime.fromMillis(tokenInfo.exp * 1000).toJSDate(),
    };
    Array.isArray(tokenInfo.role)
      ? (userSource.roles = tokenInfo.role)
      : userSource.roles.push(tokenInfo.role);

    localStorage.setItem('token', result.token);
    this.currentUserSource.next(userSource);
    console.log(userSource);
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  getToken() {
    return localStorage.getItem('token');
  }
}
