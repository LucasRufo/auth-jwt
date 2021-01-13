import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../entities/login';
import { environment } from '../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  auth(login: Login): Observable<any> {
    return this.http.post(environment.baseUri + "auth", login);
  }
}
