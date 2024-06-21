import { ValidationErrors } from '@angular/forms';
import { Constants } from '../../constants';

export class BasePageClass {
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
}
