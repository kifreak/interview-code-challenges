using Kifreak.MartianRobots.Console.ViewModel;

namespace Kifreak.MartianRobots.Console.Expressions.Interfaces
{
    public interface IExpression
    {
        void Interpret(EntryData context, string property, string item);
    }
}