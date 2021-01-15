import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Login } from '../entities/login';
import { AuthService } from '../services/auth.service';
import { JwtService } from '../services/jwt.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formLogin: FormGroup;

  login: Login;

  hasError: boolean;

  loaded: boolean;

  get email() {
    return this.formLogin.get("email");
  }

  get senha() {
    return this.formLogin.get("senha");
  }

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private jwtService: JwtService,
    private router: Router,
    private toast: ToastrService
  ) {
    this.login = { email: "", senha: "" };

    this.hasError = false;

    this.loaded = true;

    this.formLogin = this.fb.group({
      email: ['', [
        Validators.required
      ]],
      senha: ['', [
        Validators.required,
      ]]
    });
  }

  ngOnInit(): void {
    this.jwtService.destroyToken();
  }

  loginUsuario(): void {
    this.loaded = false;

    let login: Login = Object.assign({}, this.formLogin.value);

    this.authService.auth(login)
      .pipe(take(1))
      .subscribe(
        data => {
          this.jwtService.saveToken(data.token);
          this.loaded = true;

          this.router.navigate(["/logged"]);
          this.showSuccess("Parabéns, você se logou!");
        },
        error => {
          this.hasError = true;
          this.loaded = true;
        }
      );
  }

  showSuccess(message: string) {
    this.toast.success(message);
  }

}
