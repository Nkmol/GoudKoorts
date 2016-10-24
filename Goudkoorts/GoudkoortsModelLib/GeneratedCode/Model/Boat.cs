﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GoudkoortsModelLib.GeneratedCode.Model;

namespace Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Boat : MovingObject
	{
        public readonly Point direction;
        public static int MAX_CARGO = 8;

        public bool Docked
        {
            get;
            set;
        }

        public SailTile Tile
        {
            get;
            set;
        }

		public virtual int Cargo
		{
			get;
			private set;
		}

        public Boat(SailTile tile)
        {
            direction = new Point(-1, 0); // Boat always moves from right to left.

            Tile = tile;

        }

        public bool addCargo()
        {
            if(Cargo >= MAX_CARGO)
                return false;

            Cargo++;

            return true;
        }

        public void Dock()
        {
                // Check if the boat should dock
                int x = Tile.Coords.x;
                int y = Tile.Coords.y - 1;
                
                if(Tile.Board.Field[x][y] is PortTile)
                {
                    if (Cargo < MAX_CARGO)
                        Docked = true;
                    else {
                        Docked = false;
                        Move();
                    }
                }
            
        }

        public override void Tick()
		{
            // Move Ship
            //Cargo = 8;

            

            Dock();
		    // Psuedo code
		    // Get next VaarVak : Vak.Board.SetVak(this, Vak.Coords + direction);
		}


        public override void Move()
        {
            Point newCoords = Tile.Coords + Tile.Direction;

            //TODO Check if we can get rid of the cast
            Tile tile = Tile.Board.Field[newCoords.x][newCoords.y];

            if(tile != null)
            {
                if (tile is SailTile)
                {
                    SailTile nextTile = (SailTile)tile;

                    Tile.Contain = null;
                    nextTile.Contain = this;
                    //Tile.Board.Field[newCoords.x][newCoords.y] = nextTile;
                }
            }


        }
    }
}

