import { Component } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { User } from '../../models/user';
import { LocalService } from '../../services/local.service';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatCardModule, MatFormFieldModule, FormsModule, MatButtonModule, MatInputModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  errorMessage: string = '';

  constructor(private loginService: LoginService, 
      private localService : LocalService) {}

  onLogin() {
    let user = new User();
    user.email = this.email;
    user.password = this.password;

    this.loginService.login(user).subscribe(
      (data) => {
        this.localService.put(LocalService.AuthTokenName, data);
        window.location.href = "/";
      },
      (errorResponse) => {
        this.errorMessage = errorResponse.error;
      }
    );
  }
}
