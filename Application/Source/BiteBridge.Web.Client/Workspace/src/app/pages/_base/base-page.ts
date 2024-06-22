import { FormGroup, ValidationErrors } from '@angular/forms';
import { Constants } from '../../constants';
import { PageLoaderService } from '../../services/page-loader.service';

export class BasePageClass {
  constructor(protected pageLoader: PageLoaderService) {}

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
        case Constants.VALIDATION_TYPE_NOT_MATCHING:
          return Constants.VALIDATION_NOT_MATCHING.appendArgument(
            `${errors[key].field}\n`,
            errors[key].matchingField
          );
        case Constants.VALIDATION_TYPE_MINIMUM_AGE:
          return Constants.VALIDATION_MINIMUM_AGE.appendArgument(errors[key]);
        default:
          return '';
      }
    });
  }

  isFormInvalid(
    form: FormGroup,
    submited: boolean,
    errors?: ValidationErrors | null
  ) {
    return form.invalid && submited && this.getErrorMessages(errors).length > 0;
  }

  private getPatternErrorMessage(patternError: any) {
    const { requiredPattern } = patternError;
    switch (requiredPattern) {
      case Constants.REGEX_PASSWORD.toString():
        return Constants.VALIDATION_PASSWORD;
      case Constants.REGEX_PHONE_NUMBER.toString():
        return Constants.VALIDATION_PHONE_NUMBER;
      case Constants.REGEX_ZIPCODE.toString():
        return Constants.VALIDATION_ZIP_CODE;
      default:
        return 'Required field';
    }
  }
}
