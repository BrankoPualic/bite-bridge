using MediatR;

namespace BiteBridge.Application.BusinessLogic._Base;

public class BaseCommand : IRequest
{
}

public class BaseCommand<TResponse> : IRequest<TResponse>
{
}