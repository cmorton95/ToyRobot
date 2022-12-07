using ToyRobot.Application.Commands;
using ToyRobot.Application.Entities;
using ToyRobot.Application.Exceptions;
using ToyRobot.Application.Space;
using ToyRobot.Main.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var verbose = args.Contains("--verbose");

        var table = new Table();
        var robot = new Robot(table);

        var handler = new CommandHandler();

        handler.RegisterSpace(table)
            .RegisterEntity(robot)
            .RegisterCommands(verbose);

        while (true)
        {
            var input = Console.ReadLine();
            try
            {
                var response = handler.ExecuteCommand(input ?? "");

                if (!string.IsNullOrEmpty(response))
                    Console.WriteLine(response);
            }
            catch (Exception exception) when (exception is CommandException || exception is ArgumentCountException)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}