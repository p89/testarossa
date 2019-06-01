using System.Threading.Tasks;

namespace testarossa.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task Handle(T command);
    }
}