# UnityReversi
Reversi Unity Project with Minimax AI 

by Kyle Bowden 
for COM S 437 SP2020

All art and assets were not created by myself and were imported from Unity packages from either
the linked file in the project description, for free in the Unity asset store, or from Mixamo.

The game has a MainMenu scene that contains difficulty selection, player piece selection, and a start button.

The main reversi game scene is called Reversi.
The basic game loop is as follows, the player selects a tile that they want to attempt a move at, the AI then takes a second to place their piece.

This process repeats until there are no more moves or a player loses/wins.

The Knight character acts demonstrates the three behaviors required for the project.

Idle Behavior: After the player doesn't do anything for 20 seconds the Knight sits down, and slowly looks left and right.

Victory Behavior: If the player wins, the Knight does a break dance followed by a ending pose.

Lost/Failed Behavior: If the player loses, the Knight makes a defeated gesture and falls to the floor in embarrassing agony.

To play the game:

Either build the game, or press play in the MainMenu scene. 

If you start the game in the Reversi scene the game will default to the human player being the white piece and the AI being a difficulty of beginner (depth of 1 in the minimax algorithm).
