import { Component, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { BasePageClass } from '../../_base/base-page';
import { Constants } from '../../../constants';
import * as validators from '../../../validators';
import { TooltipModule } from 'primeng/tooltip';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { PageLoaderService } from '../../../services/page-loader.service';
import { PasswordModule } from 'primeng/password';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [ReactiveFormsModule, TooltipModule, CommonModule, PasswordModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss',
})
export class SignupComponent
  extends BasePageClass
  implements OnInit, OnDestroy
{
  signupForm: FormGroup = this.fb.group({});
  formSubmited = false;
  signupErrors: string[] = [];

  constructor(
    private fb: FormBuilder,
    private renderer: Renderer2,
    private authService: AuthService,
    pageLoader: PageLoaderService
  ) {
    super(pageLoader);
  }

  get firstNameErrors() {
    return this.signupForm.get('firstName')?.errors;
  }
  get lastNameErrors() {
    return this.signupForm.get('lastName')?.errors;
  }
  get emailErrors() {
    return this.signupForm.get('email')?.errors;
  }
  get passwordErrors() {
    return this.signupForm.get('password')?.errors;
  }
  get confirmPasswordErrors() {
    return this.signupForm.get('confirmPassword')?.errors;
  }
  get dateOfBirthErrors() {
    return this.signupForm.get('dateOfBirth')?.errors;
  }
  get homeNumberErrors() {
    return this.signupForm.get('homeNumber')?.errors;
  }
  get primaryAddressErrors() {
    return this.signupForm.get('location.primaryAddress')?.errors;
  }
  get cityErrors() {
    return this.signupForm.get('location.city')?.errors;
  }
  get stateErrors() {
    return this.signupForm.get('location.state')?.errors;
  }
  get zipCodeErrors() {
    return this.signupForm.get('location.zipCode')?.errors;
  }

  ngOnInit(): void {
    this.initializeSignupForm();
  }

  ngOnDestroy(): void {
    this.formSubmited = false;
  }

  signup() {
    this.formSubmited = true;
    console.log(this.signupForm);
  }

  private initializeSignupForm() {
    this.signupForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(20)]],
      middleName: [''],
      lastName: ['', [Validators.required, Validators.maxLength(30)]],
      email: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(60)],
      ],
      password: [
        '',
        [Validators.required, Validators.pattern(Constants.REGEX_PASSWORD)],
      ],
      confirmPassword: [
        '',
        [
          Validators.required,
          validators.matchValues('password', 'confirm password'),
        ],
      ],
      dateOfBirth: [
        '',
        [Validators.required, validators.minimumAgeValidator(18)],
      ],
      homeNumber: [
        '',
        [Validators.required, Validators.pattern(Constants.REGEX_PHONE_NUMBER)],
      ],
      officeNumber: [''],
      location: this.fb.group({
        primaryAddress: ['', Validators.required],
        secondaryAddress: [''],
        city: ['', Validators.required],
        state: ['', Validators.required],
        zipCode: [
          '',
          [Validators.required, Validators.pattern(Constants.REGEX_ZIPCODE)],
        ],
      }),
    });
  }
}
