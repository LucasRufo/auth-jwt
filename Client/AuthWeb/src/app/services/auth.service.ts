import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../entities/login';
import { environment } from '../../environments/environment'
import { Observable } from 'rxjs';
import { JwtService } from './jwt.service';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper = new JwtHelperService();

  constructor(
    private http: HttpClient,
    private jwtService: JwtService) { }

  auth(login: Login): Observable<any> {
    return this.http.post(environment.baseUri + "auth", login);
  }

  isAuthenticated(): boolean {
    const token = this.jwtService.getToken();

    return !this.jwtHelper.isTokenExpired(token);
  }
}
