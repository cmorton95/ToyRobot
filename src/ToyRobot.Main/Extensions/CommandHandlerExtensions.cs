using ToyRobot.Application.Commands;
using ToyRobot.Core.Commands;

namespace ToyRobot.Main.Extensions
{
    public static class CommandHandlerExtensions 
    {
        public static ICommandHandler RegisterCommands(this ICommandHandler commandHandler, bool verbose)
        {
            return commandHandler
                .RegisterCommand(new PlaceCommand(verbose))
                .RegisterCommand(new ReportCommand())
                .RegisterCommand(new MoveCommand(verbose))
                .RegisterCommand(new LeftCommand(verbose))
                .RegisterCommand(new RightCommand(verbose));
        }
    }
}