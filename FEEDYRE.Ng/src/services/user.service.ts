import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User, RegisterUser } from '../models/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private client: HttpClient) {}

    getAll() : Observable<User[]> {
        return this.client.get<User[]>("/api/user");
    }

    add(user: User) : Observable<any> {
        return this.client.post("/api/user", user);
    }

    register(user: RegisterUser) : Observable<any> {
      return this.client.post<RegisterUser>("/api/register", user);
  }
}
