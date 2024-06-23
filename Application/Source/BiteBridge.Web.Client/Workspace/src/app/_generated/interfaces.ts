export interface IAuthorizationDto
{
	token: string;
}
export interface ICategoryEntryDto
{
	name: string;
	parentId?: number;
}
export interface ICategoryResponseDto
{
	id: number;
	name: string;
	parentId?: number;
	subCategories?: ICategoryResponseDto[];
}
export interface ILocationDto
{
	primaryAddress: string;
	secondaryAddress?: string;
	city: string;
	state: string;
	zipCode: string;
}
export interface ISigninDto
{
	email: string;
	password: string;
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
	location: ILocationDto;
}
