using ToyRobot.Application.Commands;
using ToyRobot.Application.Entities;
using ToyRobot.Application.Exceptions;
using ToyRobot.Application.Space;

var table = new Table();
var robot = new Robot(table);

var handler = new CommandHandler();

handler.RegisterSpace(table)
    .RegisterEntity(robot)
    .RegisterCommand(new PlaceCommand())
    .RegisterCommand(new ReportCommand())
    .RegisterCommand(new MoveCommand())
    .RegisterCommand(new LeftCommand())
    .RegisterCommand(new RightCommand());

while (true)
{
    var input = Console.ReadLine();
    try
    {
        var response = handler.ExecuteCommand(input ?? "");

        Console.WriteLine(response);
    }
    catch (Exception exception) when (exception is CommandException || exception is ArgumentCountException)
    {
        Console.WriteLine(exception.Message);
    }
}