using BiteBridge.Application.Dtos.Categories;

namespace BiteBridge.Application.BusinessLogic.Categories.Commands;

public class UpdateCategoryCommand(int id, CategoryEntryDto category) : BaseCommand
{
	public int Id { get; set; } = id;
	public CategoryEntryDto Category { get; set; } = category;
}

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
	public UpdateCategoryCommandValidator()
	{
		RuleFor(_ => _.Id)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Id"));

		RuleFor(_ => _.Category.Name)
			.NotEmpty()
			.WithMessage(ResourceValidation.Required.AppendArgument("Name"))
			.MaximumLength(30)
			.WithMessage(ResourceValidation.Maximum_Characters.AppendArgument("Name", "30"));

		RuleFor(_ => _.Category.ParentId)
			.NotEmpty()
			.When(_ => _.Category.ParentId.HasValue)
			.WithMessage(ResourceValidation.Required.AppendArgument("Parent id"));
	}
}

internal class UpdateCategoryCommandHandler : BaseCommandHandler<UpdateCategoryCommand>
{
	public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public override async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = await _unitOfWork.CategoryRepository.FindAsync(request.Id, cancellationToken)
			?? throw new FluentValidationException(nameof(Category), ResourceValidation.Record_Doesnt_Exist.AppendArgument(nameof(Category)));

		if (request.Category.ParentId is int parentId)
		{
			var parentCategory = await _unitOfWork.CategoryRepository.FindAsync(parentId, cancellationToken)
				?? throw new FluentValidationException(nameof(Category), ResourceValidation.Record_Doesnt_Exist.AppendArgument("Parent Category"));
		}

		var categoryWithThisName = await _unitOfWork.CategoryRepository.FindAsync(request.Category.Name, cancellationToken);

		if (categoryWithThisName is not null)
		{
			throw new FluentValidationException(nameof(Category), ResourceValidation.Record_Already_Exist.AppendArgument(nameof(Category)));
		}

		category.Name = request.Category.Name;
		category.ParentId = request.Category.ParentId;

		if (!await _unitOfWork.Save())
		{
			throw new ServerException();
		}
	}
}