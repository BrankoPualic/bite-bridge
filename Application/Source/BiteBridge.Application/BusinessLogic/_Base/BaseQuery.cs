using MediatR;

namespace BiteBridge.Application.BusinessLogic._Base;

public class BaseQuery<TResponse> : IRequest<TResponse>
{
}
