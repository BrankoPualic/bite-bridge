export interface IAuthorizationDto
{
	token: string;
}
export interface ISignupDto
{
	firstName: string;
	middleName?: string;
	lastName: string;
	email: string;
	password: string;
	confirmPassword: string;
	dateOfBirth: Date;
	homeNumber: string;
	officeNumber?: string;
	primaryAddress: string;
	secondaryAddress?: string;
	state: string;
	zipCode: string;
}
