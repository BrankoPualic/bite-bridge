namespace BiteBridge.Application.BusinessLogic.Categories.Commands;

public class RemoveCategoryCommand(int id) : BaseCommand
{
	public int Id { get; set; } = id;
}

public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
{
	public RemoveCategoryCommandValidator()
	{
		RuleFor(_ => _.Id)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Id"));
	}
}

internal class RemoveCategoryCommandHandler : BaseCommandHandler<RemoveCategoryCommand>
{
	public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public override async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = await _unitOfWork.CategoryRepository.FindAsync(request.Id, cancellationToken)
			?? throw new FluentValidationException(nameof(Category), ResourceValidation.Record_Doesnt_Exist.AppendArgument(nameof(Category)));

		_unitOfWork.CategoryRepository.Remove(category);

		if (!await _unitOfWork.Save())
		{
			throw new ServerException();
		}
	}
}