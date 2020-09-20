 Martian Robots (solution)

## Specification
Control multiple robots in a flat Mars using your console. 
## The World
The surface of Mars is a rectangular grid with two integer: X (East direction) and Y (North direction).

Each robot you want to create have a starting point (X,Y) and an orientation (North, South, West or East).

Each robot must have a list of instruction in order to move it.

When a robot go "off" the surface of Mars, is lost forever (remember it's a flat planet, now your robot is somewhere in the space or maybe have been eating by a big daemon, we don't have the resource to know it). But your robot leave a "scent" that make the other robots ignore its movement to this coordinates where will be lost.
## Actions
Each robot can do the next actions:
*   L: the robot turns left 90 degrees and remains on the current grid point.
*   R: the robot turns right 90 degrees and remains on the current grid point.
*   F: the robot moves forward one grid point in the direction of the current orientation and maintains the same orientation.

## Limitation
*	The surface of Mars cannot be bigger than 50, 50.
*	When a robot try to pass a coordinate bigger than 50, this instruction will be ignored.
*   Each robot cannot have more than 100 instructions.

## Input
The first line of input is the upper-right coordinates of the rectangular world, the lower-left coordinates are assumed to be 0, 0.

The remaining input consists of a sequence of robot positions and instructions (two lines per robot). A position consists of two integers specifying the initial coordinates of the robot and an orientation (N, S, E, W), all separated by whitespace on one line. A robot instruction is a string of the letters "L", "R", and "F" on one line.

Each robot is processed sequentially, i.e., finishes executing the robot instructions before the next robot begins execution.

Example:
```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```
## The Output

For each robot position/instruction in the input, the output should indicate the final grid position and orientation of the robot. If a robot falls off the edge of the grid the word "LOST" should be printed after the position and orientation.
```
1 1 E
3 3 N LOST
2 3 S
```

## Docker
To execute using Docker (Tested: For amd64 architecture and linux environment)
*	Build: 
```
docker build -t kifreak/mars .
```
*	Run:
```
docker run -i kifreak/mars
```

## Create your own rules!
*	Add new Actions:
	-	To add new action, just create a class inherits from IActionController. We use the property 'Name' to link up with the instructions format.
*	Add new Movements:
	-	If you want to create new ways to move your robot, just create new IMovementController. 
	-	If you want to modify the way your robot move (if the robot is  between 45º and 60º, move to ...), you´ll need to create new IRobotMovement and IRobotMoveFactory.
*	You can create new robots classes that inherits from IRobot
	-	Try this few examples (maybe will be necessary implement new IRobotMovement): 
		*	Normal robot, that randomly convert into a broken robot that doesn't turn left.
		*	Crazy robots doesn't follow your instructions.
		*	T-800 robots that if go outside of the Grid, will say: "Hasta la vista, baby". And go back to the past! (Go to its first position).
*	RobotManager its the main class of the application and has a strong dependency on Grid Model.
*	IRobot interface has a strong dependency on the Coordinates System (Defined on Position Model) and on the Instruction Model.
*	INotAllowPosition: This class is in charge of storing the Lost Position of all robots. 



