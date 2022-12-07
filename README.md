# ToyRobot
A console application to move a Toy Robot around a table.

Written in C# using .NET 7.

## Usage
Clone the repository to a working folder  
```
git clone https://github.com/cmorton95/ToyRobot  
```
Build the application.
```
dotnet restore
dotnet build
```
Run the application, optionally include the --verbose parameter to see verbose output.  
```
cd src
dotnet run --project ToyRobot.Main [--verbose]  
```

The following commands are available:
```
PLACE X,Y,F - Place the Robot at a given coordinate  
MOVE        - Move the Robot one square in its facing direction  
LEFT        - Rotate the Robot left 90 degrees  
RIGHT       - Rotate the Robot right 90 degrees  
REPORT      - Report the Robot's current location and facing direction  
HELP        - Show the help menu  
```

## Dependencies

The application is kept intentionally lightweight with minimal/no dependencies. 
Resolve dependencies by using ```dotnet restore``` in the root folder of the cloned repository.  

#### ToyRobot.Core
None.  

#### ToyRobot.Application
None.  

#### ToyRobot.Main
None.  

#### ToyRobot.UnitTests
[Moq.](https://www.nuget.org/packages/Moq)

## Sample output
```
place 0,0,north
move
report
0,1,NORTH
```
```
place 0,0,north
left
report
0,0,WEST
```
```
place 1,2,east
move
move
left
move
report
3,3,NORTH
```
```
place 5,5,east
move
report
5,5,EAST
```
```
place 5,5,north
move
report
5,5,NORTH
left
move
report
4,5,WEST
right
move
report
4,5,NORTH
```

## Design Decisions

As a general rule of thumb I wanted to make sure as much of the application is written to an interface as possible to keep testing simple and that the application remains minimal/lightweight. KISS and DRY are priority principles.

While the application could be more minimalistic, I believe the methodology used is the most sensible for keeping the application extensible without bloat.

An IoC container was specifically chosen not to be used as I believe it would be overkill for a project of this size. An IoC container could certainly be introduced later if the project were to expand, however.

### Project Structure
I chose to split this into three projects, despite the fact that the application is quite small all in all.  

These projects are split into Core, Application and Main.  

#### Core
* Interfaces for the application. 
* No (business) logic. 
* Minimal by nature.
#### Application
* Should be responsible for the vast majority of functionality.
* Business logic.
* Models.
#### Main
* A simple entry point with as little logic as possible.
* Ties functionality in Application together into something usable.

### Commands
I chose to separate the robot entity from the commands in a way where commands can be more modular and agnostic of how the robot works.  

The objective of the commands and command handler is to take input from the user, validate the input information, convert the input into what the robot expects, then allow the robot to make any further decisions on how to act on the input.

CommandHandlerExtensions exists in the Main project because it is more relevant as a shorthand for the main application.

### Robot
The robot acts based on processed input from the command handler. The robot is singly responsible for its location and making sure it doesn't fall off the edge of the table.

I had originally wanted to have the robot *not* take ownership of the space it is in, but in practice this caused more unnecessary passing around of data through functions and other ownership issues.

The robot initially implemented several interfaces named IMoveable, IPlaceable and IReports, but I found these interfaces to cause more harm than good. The IEntity interface replaced these interfaces entirely and achieves the desired result.

### Unit Tests
I chose to write unit tests for this application using only mstest and Moq. While I am aware of and have used other libraries such as Moq.AutoMocker and Fluent Assertions, I am more comfortable using simplistic asserts. Keeping to the core values, using only Moq and mstest also keeps the application and dependencies minimal.

This choice also doesn't totally rule out using AutoMocker and Fluent in the future as well, the existing tests wouldn't need to be rewritten.