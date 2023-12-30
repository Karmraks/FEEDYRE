import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { UserService } from './services/user.service';
import { User } from './models/user';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from "@angular/core";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})
export class AppComponent implements OnInit{
  
  users : User[] = [];
  title = 'feedyre';

  constructor(private userService : UserService) {}
  ngOnInit(): void {
    this.userService.getAll().subscribe(data => {
      this.users = data;
    });
  }

  onButtonClick() : void {
    let newUser = new User();
    // newUser.id = "00000000-0000-0000-0000-000000000000";
    newUser.name = "JOJO";
    newUser.email = "email@email.com";
    newUser.password = "no123";
    this.userService.add(newUser).subscribe(data =>{
      console.log("User is saved");
    });
  }
}
