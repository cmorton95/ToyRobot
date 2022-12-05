namespace ToyRobot.Application.Exceptions 
{
    public class ArgumentCountException : Exception 
    {
        public ArgumentCountException(int count, int expected) : base($"Expected {expected} arguments but got {count}")
        { }
    }
}