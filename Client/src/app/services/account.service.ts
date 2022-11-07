import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { UserLogin } from '../models/userLogin';
import { map, mapTo } from 'rxjs/operators'


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:7200/api'
  private currentUserSource = new ReplaySubject<UserLogin>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      mapTo((response: UserLogin) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      }))
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      mapTo((user: UserLogin) => {
        if (user) {
          this.setCurrentUser(user);
        }
      }
      ))
  }

  setCurrentUser(user: UserLogin) {
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next();
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }
}
