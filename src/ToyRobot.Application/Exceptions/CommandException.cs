namespace ToyRobot.Application.Exceptions 
{
    public class CommandException : Exception 
    {
        public CommandException(string userError) : base($"Command not valid: {userError}")
        { }
    }
}