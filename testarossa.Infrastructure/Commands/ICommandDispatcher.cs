using System.Threading.Tasks;

namespace testarossa.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
         Task Dispatch<T>(T command) where T : ICommand;
    }
}