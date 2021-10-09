using UnityEngine;

namespace FongMichael.Lab3
{
    public class MazeRenderer : MonoBehaviour
    {

        [SerializeField] 
        [Range(3,100)]
        public int width;

        [SerializeField] 
        [Range(3,100)]
        public int height;

        [SerializeField]
        public float cellSize;

        [SerializeField]
        [Range(0,100)]
        int litWallChance;

        [SerializeField]
        Transform wallPrefab;

        [SerializeField]
        Transform litWallPrefab;

        [SerializeField]
        Transform floorPrefab;

/*        Vector3 StartPosition = new Vector3(-width * cellSize / 2 + cellSize, 1, -height * cellSize / 2 + cellSize);*/

        // Start is called before the first frame update
        void Start()
        {
            NodeWalls[,] maze = MazeGenerator.GenerateMaze(width, height);
            Draw(maze);   
        }

        private void Draw(NodeWalls[,] maze)
        {
            var rand = new System.Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    var node = maze[i, j];
                    var position = new Vector3(-width*cellSize / 2 + i*cellSize+cellSize/2, 1, -height*cellSize / 2 + j*cellSize+cellSize/2); // This will offset the maze so that the center of the maze is at 0,0
                    //position is set at 1, since the prefab height is 2

                    var floor = Instantiate(floorPrefab, transform);
                    floor.position = position + new Vector3(0, -1, 0);//move floor down so it's even with the bottom of the walls
                    floor.localScale = new Vector3(cellSize, floor.localScale.y, cellSize);
                    floor.GetComponent<Renderer>().material.mainTextureScale = new Vector2(cellSize / 4, cellSize / 4);
                    /*wallPrefab.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 2 / cellSize); //sets the "stretching" of the prefabs nicely*/

                    //check if walls are activated for each cell
                    if (node.HasFlag(NodeWalls.UP))
                    {
                        Transform topWall;
                        if (rand.Next(0, 100) <= litWallChance)
                        {
                            topWall = Instantiate(litWallPrefab, transform);
                        }
                        else
                        {
                            topWall = Instantiate(wallPrefab, transform);
                        }

                        topWall.position = position + new Vector3(0, 0, cellSize / 2);
                        topWall.localScale = new Vector3(cellSize, topWall.localScale.y,topWall.localScale.z);
                        topWall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 2 / cellSize);
                    }

                    if (node.HasFlag(NodeWalls.LEFT))
                    {
                        Transform leftWall;
                        if (rand.Next(0, 100) <= litWallChance)
                        {
                            leftWall = Instantiate(litWallPrefab, transform);
                        }
                        else
                        {
                            leftWall = Instantiate(wallPrefab, transform);
                        }
                        leftWall.position = position + new Vector3(-cellSize / 2, 0, 0);
                        leftWall.localScale = new Vector3(cellSize, leftWall.localScale.y, leftWall.localScale.z);
                        leftWall.eulerAngles = new Vector3(0, 90, 0); // rotates the wall 90 degrees
                        leftWall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 2 / cellSize);
                    }

                    if (i == width - 1) //Last column
                    {
                        if (node.HasFlag(NodeWalls.RIGHT))
                        {
                            Transform rightWall;
                            if (rand.Next(0, 100) <= litWallChance)
                            {
                                rightWall = Instantiate(litWallPrefab, transform);
                            }
                            else
                            {
                                rightWall = Instantiate(wallPrefab, transform);
                            }
                            rightWall.position = position + new Vector3(cellSize / 2, 0, 0);
                            rightWall.localScale = new Vector3(cellSize, rightWall.localScale.y, rightWall.localScale.z);
                            rightWall.eulerAngles = new Vector3(0, 90, 0); // rotates the wall 90 degrees
                            rightWall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 2 / cellSize);
                        }
                    }

                    if (j == 0) //Last row (the higher J is, the higher it is in the game field)
                    {
                        if (node.HasFlag(NodeWalls.DOWN))
                        {
                            Transform bottomWall;
                            if (rand.Next(0, 100) <= litWallChance)
                            {
                                bottomWall = Instantiate(litWallPrefab, transform);
                            }
                            else
                            {
                                bottomWall = Instantiate(wallPrefab, transform);
                            }
                            bottomWall.position = position + new Vector3(0, 0, -cellSize / 2);
                            bottomWall.localScale = new Vector3(cellSize, bottomWall.localScale.y, bottomWall.localScale.z);
                            bottomWall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 2 / cellSize);
                        }
                    }
                }
            }
        }
    }
}
