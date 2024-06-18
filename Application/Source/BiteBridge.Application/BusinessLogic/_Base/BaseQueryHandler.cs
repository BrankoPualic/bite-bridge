namespace BiteBridge.Application.BusinessLogic._Base;

public abstract class BaseQueryHandler<TQuery, TResponse> : BaseHandler<TQuery, TResponse>
    where TQuery : BaseQuery<TResponse>
{
}
