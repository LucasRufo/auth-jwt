import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MASKS, NgBrazilValidators } from 'ng-brazil';
import { Observable, Subscription } from 'rxjs';
import { Usuario } from '../entities/usuario';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit, OnDestroy {

  public MASKS = MASKS;

  formUsuario: FormGroup;

  usuario: Usuario;

  subscription: Subscription;

  get nome() {
    return this.formUsuario.get("nome");
  }

  get documento() {
    return this.formUsuario.get("documento");
  }

  get email() {
    return this.formUsuario.get("email");
  }

  get senha() {
    return this.formUsuario.get("senha");
  }

  get confirmacaoSenha() {
    return this.formUsuario.get("confirmacaoSenha");
  }

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService
  ) {
    this.usuario = { id: 0, nome: '', documento: '', email: '', senha: '' };

    this.subscription = new Subscription();

    this.formUsuario = this.fb.group({
      id: 0,
      nome: ['', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(100)
      ]],
      documento: ['', [
        Validators.required,
        NgBrazilValidators.cpf
      ]],
      email: ['', [
        Validators.required,
        Validators.email,
        Validators.minLength(5),
        Validators.maxLength(60)
      ]],
      senha: ['', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(40)
      ]],
      confirmacaoSenha: ['', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(40)
      ]]
    }, { validators: this.checkPasswords });
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  checkPasswords(group: FormGroup) {
    let pass = group?.get('senha')?.value;
    let confirmPass = group?.get('confirmacaoSenha')?.value;

    return pass === confirmPass ? null : { notSame: true }
  }

  submitForm() {
    if (this.formUsuario.invalid)
      return;

    let usuario: Usuario = Object.assign({}, this.formUsuario.value);

    this.subscription = this.usuarioService.criarUsuario(usuario).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      });
  }

}
