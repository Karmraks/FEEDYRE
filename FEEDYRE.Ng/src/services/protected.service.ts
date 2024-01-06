import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalService } from './local.service';

@Injectable({
  providedIn: 'root'
})
export class ProtectedService {

  constructor(private client : HttpClient, private localService: LocalService) {}

    public getSecret() : Observable<string> {
        return this.client.get("api/protected", {responseType: "text" });
    }
}
