# ToyRobot
A console application to move a Toy Robot around a table.

## Usage
Clone the repository to a working folder  
```
git clone https://github.com/cmorton95/ToyRobot  
```
Build the application
```
dotnet build
```
Run the application, optionally include the --verbose parameter to see verbose output.  
```
cd src
dotnet run --project src/ToyRobot.Main [--verbose]  
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