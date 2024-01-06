import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private client: HttpClient) {}

  public login(user : User) : Observable<string> {
    return this.client.post("api/login", user, {responseType : "text"});
  }
}
