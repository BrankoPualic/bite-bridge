using BiteBridge.Application.Dtos.Categories;
using BiteBridge.Application.Extensions;

namespace BiteBridge.Application.BusinessLogic.Categories.Queries;

public class GetCategoriesQuery : BaseQuery<IEnumerable<CategoryResponseDto>>
{
}

internal class GetCategoriesQueryHandler : BaseQueryHandler<GetCategoriesQuery, IEnumerable<CategoryResponseDto>>
{
	public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper = null, IIdentityUser identityUser = null, IMediator mediator = null, ILogger logger = null) : base(unitOfWork, mapper, identityUser, mediator, logger)
	{
	}

	public override async Task<IEnumerable<CategoryResponseDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
	{
		var categories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken)
			?? throw new FluentValidationException(nameof(Category), ResourceValidation.Record_Doesnt_Exist.AppendArgument("Category"));

		return _mapper.To<CategoryResponseDto>(categories);
	}
}