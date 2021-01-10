import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../entities/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUri: string = "https://localhost:44342/";

  constructor(private http: HttpClient) { }

  auth(login: Login) {
    return this.http.post(this.baseUri + "auth", login);
  }
}
