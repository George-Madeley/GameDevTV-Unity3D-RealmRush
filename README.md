# Realm Rush

## About

This game was created as part of the Realm Rush section of the GameDev.tv Unity 3D course I am attending.

## Game Design

Realm Rush will be a tower defense game. The game will be positioned on a grid with one square being where enemies come into thje world and another square as the destination. The enemies will follow a fixed path and the player will place defences around this path.

### Player Experience

Tatical/strategic

### Core Mechanics

Using limited resources, strategically place towers to stop enemies from reaching their goal.

### Core Game Loop

Survive against waves of enemies for as long as possible. Level reloads when the player runs out of gold.

### Story

Defend against an invading kingdom who have come to pillage your castle

### Art

Medievel Fantasy with Voxel Art

### Tech Setup

- Platform: PC/Mac/Linux
- Aspect Ratio: 1920x1080 16:9
- Input: Mouse

### Stretch Goals

- Enemy Path finding: Enemies will dynamically change thies path
- Build Timer: Towers will take n-seconds to build

## Version

### v1.6.0

- Added a build time to the turrets.
- Game course is now complete and the game can now move on to the next stage of development.

### v1.5.5

- Finshed the path finding algorithm.

### v1.5.4

- The find path algorithm will now update if a placed turret obstructs the path.

### v1.5.3

- The find path algorithm now takes into account for blocked tiles.

### v1.5.2

- Created the Breadth-first search algorithm.
- Created a method to bachtrach the search algorithm and build the path.

### v1.5.1

- Began the creation of a Pathfinder.cs script.
- Added debugging tools to CoordinateLabeller.cs to display yellow and orange label colors for the path finder.

### v1.5.0

- Started designing new pathfinding algorithm.
- Created pure C# `Node.cs` script to hold information about a node.
- Created `GridMananger.cs` component used to hold all nodes.
- Attached `GrdiManager.cs` to empty object.

### v1.4.0

- Resdesigned Level.
- Level now contains two castles.
- Level now contains two oceans.
- Level now contains trees to block ballistas.

### v1.3.4

- Refactored code.
- Created an `Editor` folder to be used to store the `CoordinateLabeller.cs` script before building the game.

### v1.3.3

- Added a difficulty ramp to the game.

### v1.3.2

- Added UI elements which display the amount of gold a user has.

### v1.3.1

- Created a Tower.cs script responsible for instantiating tower prefabs and taking money out of the bank when doing so.
- Extended the Bank.cs script to reload the scene once the bank balance is below 0.

### v1.3.0

- Began developing a currency system.
- Created a Bank prefab.
- Created a Bank.cs script containing `Withdraw()` and `Deposit()` methods used to withdraw and deposit money respectfully.
- Called `Deposit()` any time the enemy is killed.
- Called `Withdraw()` when the enemy reaches the end.

### v1.2.6

- Improved the targetting system by getting the towers to target the closest enemy relative to them.

### v1.2.5

- Imporved ObjectPool to instantiate enemy prefabs at the start with a ability to re-use them instead of destroying them.

### v1.2.4

- Added an empty object named ObjectPool to the hierachy with a script named ObjectPool.cs
- The scripts spawns in a given enemy prefab every x amount of seconds.

### v1.2.3

- Added Debugging tools to the CoordinateLabeler.cs script.

### v1.2.2

- Added particle effects to the turret prefab
- Created a EnemyHealth.cs scripts which decreases the enemy health by one every time a particle collision occurs
- Attached the EnemyHealth.cs script to the Enemy/Ram prefab

### v1.2.1

- Added a turret to the game
- Modified the Waypoint.cs so the designer can decide what turret the player can add when they click the tile
- Created a script named TargetLocator.cs which rotates the turret so it is always pointing at the enemy

### v1.2.0

- Allowed the user to click on tiles displaying their name on the log
- Added a bool to the Waypoint.cs script that allows the designers to decide if the player can place objects on this tile.

### v1.1.2

- Changed the EnemyMover.cs script to use linear interpolation between waypoints to allow for smoother travel
- Enemy also now points in the direction they are traelling
- `waitTime` has been replaced with a speed controlling ranging from 0 to 5.

### v1.1.1

- Added the Voxel Prefabs fro the GameDev.tv Course.
- Creates a simply world with a path that the enemy follows along.
- Changed formating of the README.md file.

### v1.1.0

- Waypoint.cs script created and attached to tile object (not cube)
- Created Enemy object with cylinder child object
- Created Materials for tiles and enemy
- created EnemyMover.cs script which moves the enemy along a set path. This path is determined by the order in which tiles/waypoints appear in the list in the inspector.

### v1.0.2

- Coordinate system created.
- CoordinateLabel.cs has been completed to only run in the Unity Editor. It displays the coordinate of each tile on said tile and changes its name to the corresponding coordinate. Automatically updates when moved (only in editor, not in game).

### v1.0.1

- TMPro works!!!
- Intellisence on VSCode doesn't recognise TMPro
- CoordinateLabel.cs works in the Unity Editor

### v1.0.0

The Repository has been initialised and the Game Design has been created
