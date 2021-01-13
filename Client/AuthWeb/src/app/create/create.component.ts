import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MASKS, NgBrazilValidators } from 'ng-brazil';
import { take } from 'rxjs/operators';
import { Return } from '../entities/return';
import { Usuario } from '../entities/usuario';
import { UsuarioService } from '../services/usuario.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {

  public MASKS = MASKS;

  formUsuario: FormGroup;

  usuario: Usuario;

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
    private usuarioService: UsuarioService,
    private router: Router,
    private toast: ToastrService
  ) {
    this.usuario = { id: 0, nome: '', documento: '', email: '', senha: '' };

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

  checkPasswords(group: FormGroup) {
    let pass = group?.get('senha')?.value;
    let confirmPass = group?.get('confirmacaoSenha')?.value;

    return pass === confirmPass ? null : { notSame: true }
  }

  criarUsuario(): void {
    if (this.formUsuario.invalid)
      return;

    let usuario: Usuario = Object.assign({}, this.formUsuario.value);

    this.usuarioService.criarUsuario(usuario)
      .pipe(take(1))
      .subscribe(
        (data: Return) => {
          this.router.navigate(["/login"]);
          this.showSuccess("Usuário cadastro com sucesso!");
        },
        error => {
          Object.keys(error.error).forEach(prop => {
            const formControl = this.formUsuario.get(prop.toLowerCase());
            if (formControl) {
              formControl.setErrors({
                serverError: error.error[prop]
              });
            }
          });
        }
      );
  }

  showSuccess(message: string) {
    this.toast.success(message);
  }

  showError(message: string) {
    this.toast.error(message);
  }

}
