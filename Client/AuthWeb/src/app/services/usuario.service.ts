import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../entities/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private baseUri: string = "https://localhost:44342/";

  constructor(private http: HttpClient) { }

  criarUsuario(usuario: Usuario) {
    return this.http.post(this.baseUri + "usuario", usuario);
  }
}
