using System;
using System.Threading.Tasks;
using Autofac;

namespace testarossa.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componenContext;
        public CommandDispatcher (IComponentContext componenContext) 
        {
            _componenContext = componenContext;
        }
        public async Task Dispatch<T>(T command) where T : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command),
                $"Command {typeof(T).Name} cannot be null.");

            var handler = _componenContext.Resolve<ICommandHandler<T>>();
            await handler.Handle(command);
        }
    }
}