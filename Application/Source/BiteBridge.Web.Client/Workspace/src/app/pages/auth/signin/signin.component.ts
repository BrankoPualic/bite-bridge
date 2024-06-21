import { Component, OnInit, Renderer2 } from '@angular/core';
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
@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, TooltipModule, CommonModule],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss',
})
export class SigninComponent extends BasePageClass implements OnInit {
  signinForm: FormGroup = this.fb.group({});
  formSubmited = false;

  constructor(private fb: FormBuilder, private renderer: Renderer2) {
    super();
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

  signin() {
    this.formSubmited = true;
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
