using AutoMapper;
using BiteBridge.Application.BusinessLogic._Base;
using BiteBridge.Application.Dtos.Users;
using BiteBridge.Application.Dtos.Users.Authorization;
using BiteBridge.Application.Exceptions;
using BiteBridge.Application.Identity.Interfaces;
using BiteBridge.Common;
using BiteBridge.Common.Enums;
using BiteBridge.Common.Exceptions;
using BiteBridge.Common.Extensions;
using BiteBridge.Common.Interfaces;
using BiteBridge.Common.Resources;
using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BiteBridge.Application.BusinessLogic.Users.Commands;

public class SignupCommand : BaseCommand<AuthorizationDto>
{
	public SignupDto User { get; set; }

	public SignupCommand(SignupDto user)
	{
		User = user;
	}
}

public class SignupCommandValidator : AbstractValidator<SignupCommand>
{
	public SignupCommandValidator()
	{
		RuleFor(_ => _.User.FirstName)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("First Name"))
			.MaximumLength(20)
			.WithMessage(ResourceValidation.Maximum_Characters.AppendArgument("First Name", "20"))
			.MinimumLength(3)
			.WithMessage(ResourceValidation.Minimum_Characters.AppendArgument("First Name", "3"));

		RuleFor(_ => _.User.LastName)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Last Name"))
			.MaximumLength(30)
			.WithMessage(ResourceValidation.Maximum_Characters.AppendArgument("Last Name", "30"))
			.MinimumLength(3)
			.WithMessage(ResourceValidation.Minimum_Characters.AppendArgument("Last Name", "3"));

		RuleFor(_ => _.User.MiddleName)
			.MaximumLength(20)
			.When(_ => _.User.MiddleName.HasValue())
			.WithMessage(ResourceValidation.Maximum_Characters.AppendArgument("Middle Name", "20"))
			.MinimumLength(3)
			.When(_ => _.User.MiddleName.HasValue())
			.WithMessage(ResourceValidation.Minimum_Characters.AppendArgument("Middle Name", "3"));

		RuleFor(_ => _.User.Email)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Email"))
			.EmailAddress()
			.WithMessage(ResourceValidation.Wrong_Format.AppendArgument("Email"))
			.MaximumLength(60)
			.WithMessage(ResourceValidation.Maximum_Characters.AppendArgument("Email", "60"));

		RuleFor(_ => _.User.Password)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Password"))
			.Matches(Constants.REGEX_PASSWORD)
			.WithMessage(ResourceValidation.Password);

		RuleFor(_ => _.User.ConfirmPassword)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Confirm Password"))
			.Equal(_ => _.User.Password)
			.WithMessage(ResourceValidation.Dont_Match.AppendArgument("Password", "Confirm Password"));

		RuleFor(_ => _.User.DateOfBirth)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Date of Birth"))
			.Must(Functions.BeAtLeastEighteenYearsOld)
			.WithMessage(ResourceValidation.Minimum_Age.AppendArgument("18"));

		RuleFor(_ => _.User.HomeNumber)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Home Number"))
			.Matches(Constants.REGEX_PHONE_NUMBER)
			.WithMessage(ResourceValidation.Phone_Number);

		RuleFor(_ => _.User.OfficeNumber)
			.NotEmpty()
			.When(_ => _.User.OfficeNumber.HasValue())
			.WithMessage(ResourceValidation.Required.AppendArgument("Office Number"))
			.Matches(Constants.REGEX_PHONE_NUMBER)
			.When(_ => _.User.OfficeNumber.HasValue())
			.WithMessage(ResourceValidation.Phone_Number);

		RuleFor(_ => _.User.PrimaryAddress)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Primary Address"));

		RuleFor(_ => _.User.PrimaryAddress)
			.NotEmpty()
			.When(_ => _.User.SecondaryAddress.HasValue())
			.WithMessage(ResourceValidation.Required.AppendArgument("Secondary Address"));

		RuleFor(_ => _.User.State)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("State"));

		RuleFor(_ => _.User.ZipCode)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Zip Code"))
			.Matches(Constants.REGEX_ZIPCODE)
			.WithMessage(ResourceValidation.Zip_Code);
	}
}

internal class SignupCommandHandler : BaseCommandHandler<SignupCommand, AuthorizationDto>
{
	private readonly ITokenService _tokenService;
	private readonly IUserManager _userManager;

	public SignupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper = null, IIdentityUser identityUser = null, IMediator mediator = null, ILogger logger = null, ITokenService tokenService = null, IUserManager userManager = null)
		: base(unitOfWork, mapper, identityUser, mediator, logger)
	{
		_tokenService = tokenService;
		_userManager = userManager;
	}

	public override async Task<AuthorizationDto> Handle(SignupCommand request, CancellationToken cancellationToken)
	{
		bool user_exist = await _unitOfWork.UserRepository.UserExistAsync(request.User.Email, cancellationToken);

		if (user_exist)
		{
			throw new FluentValidationException(nameof(request.User.Email), ResourceValidation.Entity_Already_Exist.AppendArgument("User"));
		}

		User user = new();

		request.User.ToModel(user, _userManager);

		_unitOfWork.UserRepository.Add(user);

		return await _unitOfWork.Save()
			? new AuthorizationDto()
			{
				Token = _tokenService.GenerateJwtToken(
				user.Id,
				Functions.GetStringValuesFromEnums(eSystemRole.Member),
				string.Join(" ", user.FirstName, user.MiddleName, user.LastName),
				user.Email)
			}
			: throw new ServerException();
	}
}