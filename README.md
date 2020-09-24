# Game Concept

## idea
- Puzzle game
- Stealth
- [Try > Fail > Learn > Try] Cycle
- Levels
- First Person
- Pigs & Wolves

Our game is about a pigwho has to go to his house. The pig dies if it is seen by a wolf. The wolf patrols the world so the pig has to 
hide behind objects and movable boxes to go to the house without being seen by the wolf.
In later levels more houses are added so when a pig reaches the first house he has to go to the second house, 
the first house then becomes a checkpoint so when the pig gets seen by the wolf between house one and two he can respawn to house one and start from there. 
To add more difficulty in later levels the pig has to get keys first before he can go to the house in this way he has to walk around longer and 
pass the wolf multiple times. 

## design decissions
### game-structure
- The game exists out of levels, levels will be unlocked after completing previous levels
- Each levels has a start- and finish point
- Each levels has at least one enemy (wolf) that may be stationary, or patrols the level
- Each level can optionally contain:
	-	checkpoints: subgoals that act as respawn location, to prevent a feeling of repetion and grind if the player has trouble with a level.
	- objectives: players may have to complete a task or get a item in order to extend the level complexity and difficulty.
	- movables: some objects in the level can be pushed/pulled/picked-up by the player, in order to progress

### game-cycle
- Each level starts with the player's spawn at the starting point
	- Each level has 4 states:
		1. [CYCLE END] the finish point has been reached by the player
		2. [CYCLE END] the player dies by detection
		3. [CYCLE END] the player quits the level
		4. [CYCLE CONTINUES] the player is detected, but may respawn
	- state 1 (level completed):
		- the player must not have quit (this would be state 3)
		- the player must not be detected (this will result in state 2)
		- the player must complete all objectives if present
		- the player must reach the finish-point
		- the player will unlock a new level
	- state 2 (level failed):
		- the player must not have quit (this would be state 3)
		- the player must have been detected
		- the player must not have any respawn point available
		- the player will not unlock a new level
		- all progress in the level will be lost
	- state 3 (player quit):
		- the player must have pressed the quit button
		- the player will lose any progress made in the level
		- the player will not unlock a next level
	- state 4 (the player respawns):
		- the player must have at least one respawn point available
		- the player must be detected
		- the player must not have quit (state 3)
		- the player must not have reached the finish point (state 1)
	- A player gains a respawn point when:
		- The player reaches that point in the level
	- A player looses a respawn point when:
		- The player is detected (which would otherwise trigger state 2)

### Player & Enemy attributes
- Player:
	- Can move around the level by walking and jumping (no croughing or climbing)
	- Can interact with Movable Objects (by pushing, pulling or grabbing them)
	- Will collide with Enviroment Obstacles, Movable Objects and Enemies
	- Can die (state 2)
	- Can (re)spawn at a player spawn location (level start, state 4)
	- Can use a Finish trigger (state 1)
	- Can use a Objective trigger
	- Can quit (state 3)
- Enemy:
	- Can move around the level on a set path (no croughing, jumping or climbing)
	- Will collide with Enviroment Obstacles, Movalbe Objects and Player
	- Can see in a scanning cone (a field of view)
	- Can see in a small radius around itself (sensory range, to prevent following the wolf 1cm behinds its back)
		- Can spot player (state 2, state 4)
	- Can spawn at a Enemy Spawn location
	

### game objects
This is a list of all objects within the game:
- Player Object (Pig): The player...
- Enemy Object (Wolf): Antagonist of the player, responsible for game-over (state 2)
- Enviroment Objstacle: Object part of the level enviroment, the player can collide with. Object may or may not have a gameplay function.
- Movable Object: Object the player can move, to alter the enviroment, in order to progress.
- Visual Object: Object that does not hava collision or interacts with the player, but serves the asteathic en athmosphere of the game.
- Objective trigger: Event that allows the player to progress, may be in the form of an object, or condition the player needs to satisfy.
- Player Spawn point: Location where the player spawns (either at the start or after a checkpoint)
- Enemy Spawn point: Location where the enemy spawns
- Finish trigger: Event that invokes a postive level ending (state 1), a condition the player needs to satisfy (positional and other)
