import { HttpInterceptorFn } from '@angular/common/http';
import { LocalService } from '../../services/local.service';
import { inject } from '@angular/core';

export const authinterInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(LocalService);
  console.log('Intercepting request...');
  let token = tokenService.get(LocalService.AuthTokenName);
  if (token) {
    req = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
  }
  return next(req);
};
