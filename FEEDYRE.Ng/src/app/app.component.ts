import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { TopMenuComponent } from "./top-menu/top-menu.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [CommonModule, RouterOutlet, HttpClientModule, MatButtonModule, TopMenuComponent]
})
export class AppComponent{
  title(title: any) {
    throw new Error('Method not implemented.');
  }
  

  //ALL USERS
  // users : User[] = [];
  // title = 'feedyre';

  // constructor(private userService : UserService) {}
  // ngOnInit(): void {
  //   this.userService.getAll().subscribe(data => {
  //     this.users = data;
  //   });
  // }

  // onButtonClick() : void {
  //   let newUser = new User();
  //   // newUser.id = "00000000-0000-0000-0000-000000000000";
  //   newUser.name = "JOJO";
  //   newUser.email = "email@email.com";
  //   newUser.password = "no123";
  //   this.userService.add(newUser).subscribe(() =>{
  //     console.log("User is saved");
  //   });
  // }
}
