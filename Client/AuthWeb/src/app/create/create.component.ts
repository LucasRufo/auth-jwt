import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Usuario } from '../entities/usuario';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  formUsuario: FormGroup;

  usuario: Usuario;

  constructor(private fb: FormBuilder) {
    this.usuario = { id: 0, nome: '', documento: '', email: '', senha: '' };

    this.formUsuario = this.fb.group({
      id: '',
      nome: ['', [
        Validators.required,
      ]],
      documento: ['', [
        Validators.required
      ]],
      email: ['', [
        Validators.required
      ]],
      senha: ['', [
        Validators.required,
      ]],
      confirmacaoSenha: ['', [
        Validators.required
      ]]
    });
  }

  ngOnInit(): void {
  }

  teste() {
    console.log(this.formUsuario.value);
  }

}
