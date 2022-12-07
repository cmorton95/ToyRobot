using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Commands;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.Application.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private Dictionary<string, ICommand> Commands { get; } = new();
        private IEntity? Entity { get; set; }
        private ISpace? Space { get; set;}
        private readonly string _helpString = "HELP";

        public string ExecuteCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new CommandException("No command given");

            if (Entity == null)
                throw new InvalidOperationException("Entity not registered");

            if (Space == null)
                throw new InvalidOperationException("Space not registered");

            if (Commands.Count == 0)
                throw new InvalidOperationException("Commands not registered");

            var commandSplit = command.Split(" ");

            var commandUp = commandSplit.First().ToUpper();
            var args = commandSplit.Skip(1).ToArray();

            if (string.Equals(commandUp, _helpString))
            {
                return GetHelp(args?.FirstOrDefault() ?? "");
            }

            if (Commands.ContainsKey(commandUp)) 
            {
                var finalCommand = Commands[commandUp];
                var response = finalCommand.Execute(Entity, args);
                return finalCommand.Verbose ? response : string.Empty;
            }
            return "Command not found";
        }

        public ICommandHandler RegisterCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (Commands.ContainsKey(command.Name.ToUpper()))
                throw new InvalidOperationException($"Only one command by name '{command.Name}' may be registered");
            
            Commands.Add(command.Name.ToUpper(), command);
            return this;
        }

        public ICommandHandler RegisterEntity(IEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entity = entity;
            return this;
        }

        public ICommandHandler RegisterSpace(ISpace space)
        {
            if (space == null)
                throw new ArgumentNullException(nameof(space));

            Space = space;
            return this;
        }

        private string GetHelp(string command = "")
        {
            if (string.IsNullOrEmpty(command)) 
            {
                return string.Join(Environment.NewLine, Commands.Select(kvp => kvp.Value.Help));
            }
            else
            {
                var commandUp = command.ToUpper();
                if (Commands.ContainsKey(commandUp)) 
                {
                    return Commands[commandUp].LongHelp;
                }
                return "Command not found";
            }
        }
    }
}