using BiteBridge.Application.Dtos.Users;
using BiteBridge.Application.Dtos.Users.Authorization;

namespace BiteBridge.Application.BusinessLogic.Users.Commands;

public class SigninCommand(SigninDto user) : BaseCommand<AuthorizationDto>
{
	public SigninDto User { get; set; } = user;
}

public class SigninCommandValidator : AbstractValidator<SigninCommand>
{
	public SigninCommandValidator()
	{
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
	}
}

internal class SigninCommandHandler : BaseCommandHandler<SigninCommand, AuthorizationDto>
{
	private readonly ITokenService _tokenService;
	private readonly IUserManager _userManager;

	public SigninCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IUserManager userManager) : base(unitOfWork)
	{
		_tokenService = tokenService;
		_userManager = userManager;
	}

	public override async Task<AuthorizationDto> Handle(SigninCommand request, CancellationToken cancellationToken)
	{
		var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.User.Email, cancellationToken);

		if (user is null)
		{
			throw new FluentValidationException(nameof(request.User), ResourceValidation.Wrong_Credentials.AppendArgument("Email", "Password"));
		}

		bool passwordMatch = _userManager.VerifyPassword(request.User.Password, user.Password);

		if (!passwordMatch)
		{
			throw new FluentValidationException(nameof(request.User), ResourceValidation.Wrong_Credentials.AppendArgument("Email", "Password"));
		}

		SigninLog log = new()
		{
			Id = Guid.NewGuid(),
			UserId = user.Id,
			RecordDate = DateTime.UtcNow,
		};

		_unitOfWork.UserRepository.LogSignin(log);

		var userRoles = user.UserRoles.Select(_ => _.Role.Name).ToArray();

		return await _unitOfWork.Save()
			? new AuthorizationDto
			{
				Token = _tokenService.GenerateJwtToken(
					user.Id,
					userRoles,
					Functions.GetUserFullName(user.FirstName, user.LastName, user.MiddleName),
					user.Email)
			}
			: throw new ServerException();
	}
}