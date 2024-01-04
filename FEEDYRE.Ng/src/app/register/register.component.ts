import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSnackBar } from "@angular/material/snack-bar";
import { UserService } from '../../services/user.service';
import { RegisterUser, User } from '../../models/user';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [MatCardModule, MatFormFieldModule, FormsModule, MatButtonModule, MatInputModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  constructor(private userService: UserService,
    private snackBar: MatSnackBar) {}

  public email: string = '';
  public password: string = '';
  public errorMessage: string = '';

  onRegister() {
    let user = new RegisterUser(); 
    user.email = this.email;
    user.password = this.password;
    this.userService.register(user).subscribe(data => {
      this.snackBar.open("User is registered", "Close");
      this.errorMessage = '';
    }, errorResult => {
      this.errorMessage = errorResult.error;
    });
  }
}
