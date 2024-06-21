import { Component, OnInit, Renderer2 } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Constants } from '../../../constants';
import { TooltipModule } from 'primeng/tooltip';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, TooltipModule, CommonModule],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss',
})
export class SigninComponent implements OnInit {
  signinForm: FormGroup = this.fb.group({});
  formSubmited = false;

  constructor(private fb: FormBuilder, private renderer: Renderer2) {}

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

  getErrorMessages(errors?: ValidationErrors | null) {
    if (!errors) return [];

    return Object.keys(errors).map((key) => {
      switch (key) {
        case Constants.VALIDATION_TYPE_REQUIRED:
          return Constants.VALIDATION_REQUIRED;
        case Constants.VALIDATION_TYPE_EMAIL:
          return Constants.VALIDATION_EMAIL;
        case Constants.VALIDATION_TYPE_PATTERN:
          return this.getPatternErrorMessage(errors[key]);
        case Constants.VALIDATION_TYPE_MAX_LENGTH:
          return Constants.VALIDATION_MAX_LENGTH.appendArgument(
            errors[key].requiredLength
          );
        default:
          return '';
      }
    });
  }

  private getPatternErrorMessage(patternError: any) {
    const { requiredPattern } = patternError;
    if (requiredPattern === Constants.REGEX_PASSWORD.toString()) {
      return Constants.VALIDATION_PASSWORD;
    }
    return '';
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
