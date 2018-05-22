using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        //Functions and veriables go here
        //Class needs to contain functions and variables
        public int x, y;
        public bool isMine = false; //Is the current tile a mine?
        public bool isRevealed = false; //Has the tile already been revealed
        [Header("Refrences")]
        public Sprite[] emptySprites; // List of empty sprites i.e empty 1, 2, 3 ect
        public Sprite[] mineSprites; //The mine sprites
        private SpriteRenderer rend; //Refrence to the sprite render 

        void Awake()
        {
            //Grab refrence to sprite renderer
            rend = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            //randomly decide if this tile is a mine - using a 5% chance
            isMine = Random.value < 0.5f;
        }

        public void Reveal(int adjacentMines, int mineState=0)
        {
            // Flags the tile as being revealed
            isRevealed = true;
            //Checks if tile is a mine
            if (isMine)
            {
                // Sets sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                //Sets sprite to approximate testure based in adjacent mines
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}
