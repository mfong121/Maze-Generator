using System.Collections.Generic;

namespace FongMichael.Lab3
{
    public enum NodeWalls //create a 2D array of these
    {
        LEFT = 1,   //0001
        RIGHT = 2,  //0010
        UP = 4,     //0100
        DOWN = 8,   //1000

        VISITED = 128, //1000 0000
        COIN_PLACED = 64 //0100 0000
        
    }
    //can use maze[i,j].HasFlag(NodeWalls.DIRECTION) to instantiate prefabs
    public struct NodePosition
    {
        public int x;
        public int y;
    }

    public struct NodeNeighbor
    {
        public NodeWalls walls;
        public NodePosition position;
    }

    public class MazeGenerator
    {

        public static NodeWalls[,] Mazify(NodeWalls[,] maze, int mazeWidth, int MazeHeight)
        {
            //using recursive backtracking algorithm
            var rand = new System.Random();
            var visitStack = new Stack<NodePosition>();
            NodePosition startingPosition = new NodePosition
            {
                x = rand.Next(0, mazeWidth),
                y = rand.Next(0, MazeHeight)
            };
            maze[startingPosition.x, startingPosition.y] |= NodeWalls.VISITED;
            visitStack.Push(startingPosition);

            while (visitStack.Count > 0)
            {
                var currentPosition = visitStack.Pop();
                var neighbors = getUnvisitedNeighborNodes(currentPosition, maze, mazeWidth, MazeHeight);

                if (neighbors.Count > 0) //Need the current position back on stack since it has more neighbors
                {
                    visitStack.Push(currentPosition);

                    var randomNeighborIndex = rand.Next(0, neighbors.Count); //obtain a random neighbor to add to the stack
                    var randomNeighbor = neighbors[randomNeighborIndex];

                    var neighborPosition = randomNeighbor.position;
                    maze[neighborPosition.x, neighborPosition.y] &= ~randomNeighbor.walls; //Removes the shared wall from the neighbor's perspective
                    maze[currentPosition.x, currentPosition.y] &= ~getOppositeWalls(randomNeighbor.walls); //Removes the shared wall from the current node's perspective
                    //Tilde(~) gets the bitwise complement
                    //so 1101 (right side open) would turn into 0010, meaning that 1s are empty and 0s are walls
                    maze[neighborPosition.x, neighborPosition.y] |= NodeWalls.VISITED; //sets the neighbor node as a visited node

                    visitStack.Push(neighborPosition);
                }
            }
            maze[0, 0] &= ~NodeWalls.DOWN;
            maze[mazeWidth-1, MazeHeight-1] &= ~NodeWalls.UP;
            return maze;
        }

        public static NodeWalls getOppositeWalls(NodeWalls walls)
        {
            switch (walls)
            {
                case NodeWalls.LEFT: return NodeWalls.RIGHT;
                case NodeWalls.RIGHT: return NodeWalls.LEFT;
                case NodeWalls.UP: return NodeWalls.DOWN;
                case NodeWalls.DOWN: return NodeWalls.UP;
                default:
                    //something went wrong
                    return NodeWalls.LEFT; //shouldn't ever see NodeWalls.VISITED because we only check unvisited nodes?

                    


            }
        }

        public static List<NodeNeighbor> getUnvisitedNeighborNodes(NodePosition pos, NodeWalls[,] maze, int mazeWidth, int mazeHeight)
        {
            List<NodeNeighbor> neighbors = new List<NodeNeighbor>();

            if (pos.x > 0)
            {
                if (!maze[pos.x - 1, pos.y].HasFlag(NodeWalls.VISITED)) //Checking the node to the left
                {
                    neighbors.Add(new NodeNeighbor
                    {
                        walls = NodeWalls.RIGHT, //Should be the RIGHT since we moved LEFT from the original node
                        position = new NodePosition
                        {
                            x = pos.x - 1,
                            y = pos.y
                        }
                    });
                }
            }

            if (pos.x < mazeWidth - 1)
            {
                if (!maze[pos.x + 1, pos.y].HasFlag(NodeWalls.VISITED)) //Checking the node to the right
                {
                    neighbors.Add(new NodeNeighbor
                    {
                        walls = NodeWalls.LEFT, //Should be the LEFT since we moved RIGHT from the original node
                        position = new NodePosition
                        {
                            x = pos.x + 1,
                            y = pos.y
                        }
                    });
                }
            }

            if (pos.y > 0)
            {
                if (!maze[pos.x, pos.y - 1].HasFlag(NodeWalls.VISITED)) //Checking the node below
                {
                    neighbors.Add(new NodeNeighbor
                    {
                        walls = NodeWalls.UP, //Should be the UP since we moved DOWN from the original node
                        position = new NodePosition
                        {
                            x = pos.x,
                            y = pos.y - 1
                        }
                    });
                }
            }

            if (pos.y < mazeHeight - 1)
            {
                if (!maze[pos.x, pos.y + 1].HasFlag(NodeWalls.VISITED)) //Checking the node above
                {
                    neighbors.Add(new NodeNeighbor
                    {
                        walls = NodeWalls.DOWN, //Should be the DOWN since we moved UP from the original node
                        position = new NodePosition
                        {
                            x = pos.x,
                            y = pos.y + 1
                        }
                    });
                }
            }

            return neighbors;
        }

        public static NodeWalls[,] GenerateMaze(int width, int height) //Made static so that other classes in the project can use it -- and I will only need one generator
        {
            NodeWalls[,] maze = new NodeWalls[width, height];

            NodeWalls initial = NodeWalls.LEFT | NodeWalls.RIGHT | NodeWalls.UP | NodeWalls.DOWN;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i, j] = initial; // Will set all nodes to be closed off to start
                }
            }

            maze = Mazify(maze, width, height); //implements the recursive backtracking algorithm
            return maze;
        }
    }
}
