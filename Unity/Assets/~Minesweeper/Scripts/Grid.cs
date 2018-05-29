using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        //Functions & Variables go here
        public GameObject tilePrefab;
        public int width = 10, height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;

        Tile SpawnTile(Vector3 pos)
        {
            //Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);

            //Edit it's properties
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();

            //Return it
            return currentTile;

        }


        void GenerateTiles()
        {
            //Create a new 2D array of size width x height
            tiles = new Tile[width, height];
            //Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //NOTE: Part 2 goes here

                    //Store half size for later use
                    Vector2 halfSize = new Vector2(width * 0.5f,
                                                   height * 0.5f);
                    //Pivoy tiles around the grid
                    Vector2 pos = new Vector2(x - halfSize.x,
                                                y - halfSize.y);

                    Vector2 offset = new Vector2(.5f, .5f);
                    
                    //Apply spacing
                    pos *= spacing;

                    //Spawn the tile using spawn functiuon made earlier
                    Tile tile = SpawnTile(pos);

                    //Sttach newly spawned tile to self (transform)
                    tile.transform.SetParent(transform);

                    //Store its array coordinates within itself for future refrence
                    tile.x = x;
                    tile.y = y;

                    //Store tile in array at those coordinates
                    tiles[x, y] = tile;

                }

            }

        }

        void Start()
        {
            GenerateTiles();
        }

        public int GetAdjacentMineCount(Tile tile)
        {
            //Set count to zero

            int count = 0;
            //Loop through all hte adjacent tiles on the X
            for (int x = -1; x <= 1; x++)
            { //Loop through all the adjacent tiles on the Y
                for (int y = -1; y <= 1; y++)
                {
                    //calculate which adjacent tile to look at
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    //Check if the desired x and y is outside bounds
                    if (desiredX < 0 || desiredX >= width ||
                       desiredY < 0 || desiredY >= height)
                    {
                        //Continue to next element in loop
                        continue;
                    }

                    //Select current tile
                    Tile currentTile = tiles[desiredX, desiredY];
                    //Check if that tile is a mine
                    if (currentTile.isMine)
                    {
                        //Increment count by 1
                        count++;
                    }
                }
            }
            //Remember to return the count!
            return count;
        }

        void SelectATile()
        {
            //Generate a ray from the camera with the mouse position
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Perform Raycast
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            //If the mouse hit something 
            if (hit.collider != null)
            {
                //try getting a tile componemt for the next thing that we hit
                Tile hitTile = hit.collider.GetComponent<Tile>();
                //check if the thing that it hit was a tile
                if (hitTile != null)
                {
                    //Gt a count of all the mines around the hit tile
                    int adjacentMines = GetAdjacentMineCount(hitTile);
                    //reveal what that hit tile is 
                    hitTile.Reveal(adjacentMines);
                }
            }
        }

        void Update()
        {
            //Check if Mouse Button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if(hit.collider !=null)
                {
                    Tile hitTile = hit.collider.GetComponent<Tile>();
                    if(hitTile != null)
                    {
                        SelectTile(hitTile);
                    }
                }
            }
        }

        void FFuncover(int x, int y, bool[,] visited)
        {
            if (x <= 0 && y >= 0 && x < width && y < height)
            {
                //Have these coordinates been visited?
                if (visited[x, y])
                    return;
                //Reveal tile in that x and y coordinate
                Tile tile = tiles[x, y];
                int adjacentMines = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMines);

                //If there were no adjacent mines in that tile
                if (adjacentMines == 0)
                {
                    //This tile has been visited
                    visited[x, y] = true;

                    //Visit all other tiles around this tile
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x , y+ 1, visited);

                }
            }
        }

        //Uncover all mines in the grid
        void UncoverMines(int mineState =0 )
        {
            //Loop through 2D array
            for (int x=0; x< width; x++)
            {
                for (int y=0; y< height; y++)
                {
                    Tile tile = tiles[x, y];
                    //Check if tile is a mine
                    if (tile.isMine)
                    {
                        //Reveal that tile
                        int adjacentMines = GetAdjacentMineCount(tile);
                        tile.Reveal(adjacentMines, mineState);
                    }
                }
            }
        }

        //Scans the grid to check if htere are no more empty tiles
        bool NoMoreEmptyTiles()
        {
            //Set the empty tile count to zero
            int emptyTileCount = 0;
            // Loop through 2D array
            for (int x=0; x< width; x++)
            {
                for (int y=0; y< height; y++)
                {
                    Tile tile = tiles[x, y];
                    //If the tile is not revelaled and not a mine
                    if (!tile.isRevealed && !tile.isMine)
                    {
                        //We found an empty tile!
                        emptyTileCount += 1;
                    }
                }
            }

            //If there are any tiles return true
            //If there are no empty tiles refutn false
            return emptyTileCount == 0;

        }

        //Uncovers a selected tile

        void SelectTile(Tile selected)
        {
            int adjacentMines = GetAdjacentMineCount(selected);
            selected.Reveal(adjacentMines);

            //Is the selected tile a mine?
            if (selected.isMine)
            {
                UncoverMines();
            }

            else if (adjacentMines==0)
            {
                int x = selected.x;
                int y = selected.y;

                FFuncover(x, y, new bool[width, height]);
            }

            if(NoMoreEmptyTiles())
            {
                UncoverMines(1);
            }
        }
    }
}