using Cortex.Mediator.Commands;

namespace eb7461u20221e646.API.Shared.Infrastructure.Mediator.Cortex.Configuration;

public class LoggingCommandBehavior<TCommand> : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(TCommand command, CommandHandlerDelegate next, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Starting command: {typeof(TCommand).Name}");
        await next();
    }
}