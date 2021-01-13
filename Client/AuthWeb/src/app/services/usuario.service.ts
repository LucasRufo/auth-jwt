import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../entities/usuario';
import { environment } from '../../environments/environment'
import { Observable } from 'rxjs';
import { Return } from '../entities/return';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  criarUsuario(usuario: Usuario): Observable<Return> {
    return this.http.post<Return>(environment.baseUri + "usuario", usuario);
  }
}
