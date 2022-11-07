import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserLogin } from 'src/app/models/userLogin';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  currentUser$: Observable<UserLogin>;

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.router.navigateByUrl('/book');
      },
    })
  }

  logout() {
    this.accountService.logout();
  }

  // setCurrentUser() {
  //   const user: UserLogin = JSON.parse(localStorage.getItem('user') ?? '{}');
  //   this.accountService.setCurrentUser(user);
  // }



}
