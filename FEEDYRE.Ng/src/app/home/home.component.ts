import { Component } from '@angular/core';
import { ProtectedService } from '../../services/protected.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatButtonModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  secret : string = '';

  constructor(private protectedService : ProtectedService, 
    private _snackBar : MatSnackBar) {}


  onGetSecret() {
    this.protectedService.getSecret().subscribe(secret => {
      console.log(secret);
      this.secret = secret;
    }, 
    error => {
      console.log(error);
      this._snackBar.open("No access");
    })
  }
}
