namespace BiteBridge.Application.BusinessLogic._Base;

public abstract class BaseCommandHandler<TCommand> : BaseHandler<TCommand>
    where TCommand : BaseCommand
{
}

public abstract class BaseCommandHandler<TCommand, TResponse> : BaseHandler<TCommand, TResponse>
    where TCommand : BaseCommand<TResponse>
{
}