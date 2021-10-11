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
        private int litWallChance;

        [SerializeField]
        [Range(0,100)]
        private int coinChance;

        [SerializeField]
        Transform wallPrefab;

        [SerializeField]
        Transform litWallPrefab;

        [SerializeField]
        Transform floorPrefab;
        
        [SerializeField]
        Transform coinPrefab;

        [SerializeField]
        Transform goalPrefab;

        private int numCoins;
        private bool gameWin;

/*        Vector3 StartPosition = new Vector3(-width * cellSize / 2 + cellSize, 1, -height * cellSize / 2 + cellSize);*/

        // Start is called before the first frame update
        void Start()
        {
            numCoins = 0;
            gameWin= false;
            NodeWalls[,] maze = MazeGenerator.GenerateMaze(width, height);
            placeCoins(maze);
            Draw(maze);
            addGoal();
        }

        private void addGoal()
        {
            var position = new Vector3(-width * cellSize / 2 + width-1 * cellSize + cellSize / 2, .05f, -height * cellSize / 2 + height-1 * cellSize + cellSize / 2);
            Transform richard_parker = Instantiate(goalPrefab, transform);
            richard_parker.GetComponent<WinCondition>().initialize(this);

            richard_parker.position = position;
        }
        private void placeCoins(NodeWalls[,] maze)
        {
            var rand = new System.Random();
            //Create coin prefab
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    NodeWalls currentNode = maze[i, j];
                    int numWalls = 0;
                    if (currentNode.HasFlag(NodeWalls.UP))
                    {
                        numWalls++;
                    }
                    if (currentNode.HasFlag(NodeWalls.DOWN))
                    {
                        numWalls++;
                    }
                    if (currentNode.HasFlag(NodeWalls.LEFT))
                    {
                        numWalls++;
                    }
                    if (currentNode.HasFlag(NodeWalls.RIGHT))
                    {
                        numWalls++;
                    }

                    var position = new Vector3(-width * cellSize / 2 + i * cellSize + cellSize / 2, .25f, -height * cellSize / 2 + j * cellSize + cellSize / 2);

                    if (numWalls >= 3)
                    {

                        Transform coin = Instantiate(coinPrefab, transform);
                        coin.GetComponent<CoinCollectible>().initialize(this);
                        coin.position = position;
                        currentNode |= ~NodeWalls.COIN_PLACED;
                        
                    }


                    if (!currentNode.HasFlag(NodeWalls.COIN_PLACED) && rand.Next(0, 100) <= coinChance)
                    {
                        currentNode |= ~NodeWalls.COIN_PLACED;
                        Transform coin = Instantiate(coinPrefab, transform);
                        coin.GetComponent<CoinCollectible>().initialize(this);
                        coin.position = position;
                        
                    }




                }
            }

           
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
                        topWall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 2 / cellSize); //Sets "stretching" of the prefabs nicely
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
        public void addCoin()
        {
            numCoins++;
            Debug.Log("Coins collected: " + numCoins);
        }
        public int getCoins()
        {
            return numCoins;
        }

        private void OnGUI()
        {
            if (gameWin)
            {
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 200), "Game Over:\nYou caught Richard Parker!\nWith a final score of " + getCoins() + ".");
            }
        }
        public void win()
        {
            gameWin = true;
        }
    }
}
