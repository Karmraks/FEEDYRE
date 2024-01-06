import { ApplicationConfig, PLATFORM_ID, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { LocalService } from '../services/local.service';
import { authinterInterceptor } from './interceptors/authinter.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    LocalService,
    provideHttpClient(withFetch(),withInterceptors([authinterInterceptor])), 
    provideRouter(routes), 
    provideClientHydration(), 
    provideAnimations(),
  ]
};
