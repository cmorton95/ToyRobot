using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.Core.Commands 
{
    public interface ICommandHandler 
    {
        ICommandHandler RegisterEntity(IEntity entity);
        ICommandHandler RegisterSpace(ISpace space);
        ICommandHandler RegisterCommand(ICommand command);
        string ExecuteCommand(string command);
    }
}