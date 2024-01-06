import { isPlatformBrowser } from '@angular/common';
import { Injectable } from '@angular/core';
import { Inject, PLATFORM_ID } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalService {


  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}
  public static AuthTokenName = "auth-token";
    put(name: string, value : string)  {
        localStorage.setItem(name, value);
    }

    get(name : string) : string | null {
      if (isPlatformBrowser(this.platformId)){
        console.log("FFOOORSKK");
      }else{
        console.log("NOOOOOOOOOOOO");
      }
        return localStorage.getItem(name);
    }

    // remove(name: string) {
    //     localStorage.removeItem(name);
    // }
}
