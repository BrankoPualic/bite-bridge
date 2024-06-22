import { Component, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Constants } from '../../../constants';
import { TooltipModule } from 'primeng/tooltip';
import { CommonModule } from '@angular/common';
import { BasePageClass } from '../../_base/base-page';
import { ISigninDto } from '../../../_generated/interfaces';
import { AuthService } from '../../../services/auth.service';
import { PageLoaderService } from '../../../services/page-loader.service';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, TooltipModule, CommonModule],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss',
})
export class SigninComponent
  extends BasePageClass
  implements OnInit, OnDestroy
{
  signinForm: FormGroup = this.fb.group({});
  formSubmited = false;
  signinErrors: string[] = [];

  constructor(
    private fb: FormBuilder,
    private renderer: Renderer2,
    private authService: AuthService,
    pageLoader: PageLoaderService
  ) {
    super(pageLoader);
  }

  get emailErrors() {
    return this.signinForm.get('email')?.errors;
  }
  get passwordErrors() {
    return this.signinForm.get('password')?.errors;
  }

  ngOnInit(): void {
    this.initializeSigninForm();
  }

  ngOnDestroy(): void {
    this.signinErrors = [];
  }

  toggleEyeIcon(icon: HTMLElement, passwordField: HTMLInputElement) {
    if (icon.classList.contains('pi-eye')) {
      this.renderer.removeClass(icon, 'pi-eye');
      this.renderer.addClass(icon, 'pi-eye-slash');
      passwordField.type = 'text';
    } else if (icon.classList.contains('pi-eye-slash')) {
      this.renderer.removeClass(icon, 'pi-eye-slash');
      this.renderer.addClass(icon, 'pi-eye');
      passwordField.type = 'password';
    }
  }

  async signin() {
    this.formSubmited = true;
    if (this.signinForm.invalid) {
      return;
    }

    const signinUser: ISigninDto = this.signinForm.value;

    try {
      this.pageLoader.showLoader();
      await this.authService.signin(signinUser).toResult();
    } catch (ex) {
      const errors: string[] = (ex as HttpErrorResponse).error.error.user;
      this.signinErrors = errors;
      throw ex;
    } finally {
      this.pageLoader.hideLoader();
    }
  }

  private initializeSigninForm() {
    this.signinForm = this.fb.group({
      email: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(60)],
      ],
      password: [
        '',
        [Validators.required, Validators.pattern(Constants.REGEX_PASSWORD)],
      ],
    });
  }
}
