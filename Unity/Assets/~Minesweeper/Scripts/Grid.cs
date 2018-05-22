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
    }
}
