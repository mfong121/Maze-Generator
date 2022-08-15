# cse3541-lab3
Randomly generated complete maze (it is possible to reach every cell)
Maze is generated using cell nodes with a flag for each wall direction (up, down, left, right walls) and recursive backtracking algorithm.

User is able to adjust width and height of the maze through the MazeRenderer component in the hierarchy. User can also adjust cell size and frequenct of lit walls and coins.
Coins are generated at every dead-end and randomly throughout the maze. They play a pickup sound and increase score when collected.

WASD to move
Mouse controls camera rotation
Hold SHIFT to sprint