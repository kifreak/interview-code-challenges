using System.Threading.Tasks;

namespace Kifreak.MartianRobots.Console.CommandFactory
{
    public interface ICommand
    {
        Task Execute();

        bool Validate();
    }
}