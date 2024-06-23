export class Constants {
  // Routes
  static readonly ROUTE_NOT_FOUND = 'not-found';
  static readonly ROUTE_UNAUTHORIZED = 'unauthorized';
  static readonly ROUTE_AUTH = 'auth';
  static readonly ROUTE_AUTH_SIGNUP = 'signup';
  static readonly ROUTE_AUTH_SIGNIN = 'signin';

  // Route Titles
  static readonly TITLE = 'LinkUp';

  // RegEx

  static readonly REGEX_PASSWORD =
    /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$/;
  static readonly REGEX_ZIPCODE = /^\d{5}(-\d{4})?$/;
  static readonly REGEX_PHONE_NUMBER = /^\d{3}-\d{3}-\d{4}$/;

  // Validation Types

  static readonly VALIDATION_TYPE_REQUIRED = 'required';
  static readonly VALIDATION_TYPE_EMAIL = 'email';
  static readonly VALIDATION_TYPE_PATTERN = 'pattern';
  static readonly VALIDATION_TYPE_MAX_LENGTH = 'maxlength';
  static readonly VALIDATION_TYPE_NOT_MATCHING = 'notMatching';
  static readonly VALIDATION_TYPE_MINIMUM_AGE = 'minimumAge';

  // Validation Messages

  static readonly VALIDATION_REQUIRED = 'Required field';
  static readonly VALIDATION_EMAIL = 'Invalid email format';
  static readonly VALIDATION_PASSWORD =
    'Password must contain at least one uppercase letter, one lowercase letter, one number, one special character, and be at least 8 characters long';
  static readonly VALIDATION_MAX_LENGTH =
    'Maximum number of characters exceeded';
  static readonly VALIDATION_NOT_MATCHING = "Fields don't match";
  static readonly VALIDATION_MINIMUM_AGE = 'Minimum age required';
  static readonly VALIDATION_PHONE_NUMBER =
    'Phone number must be in format xxx-xxx-xxxx';
  static readonly VALIDATION_ZIP_CODE =
    'Zip code must be in format 5 digits or 5 digits followed by hypen and 4 more digits';
}
