using BiteBridge.Application.Dtos.Categories;

namespace BiteBridge.Application.BusinessLogic.Categories.Commands;

public class AddCategoryCommand(CategoryEntryDto category) : BaseCommand
{
	public CategoryEntryDto Category { get; set; } = category;
}

public class AddCategoryCommandValidatior : AbstractValidator<AddCategoryCommand>
{
	public AddCategoryCommandValidatior()
	{
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

internal class AddCategoryCommandHandler : BaseCommandHandler<AddCategoryCommand>
{
	public AddCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public override async Task Handle(AddCategoryCommand request, CancellationToken cancellationToken)
	{
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

		Category category = new();

		request.Category.ToModel(category);

		_unitOfWork.CategoryRepository.Add(category);

		if (!await _unitOfWork.Save())
		{
			throw new ServerException();
		}
	}
}