﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Diagnostics;

namespace Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.Timers;

	public class Storage : ITickAble, IRunAble, IContainObject
    {
        private static int SPAWN_TIME = 15000; // Seconds
        private int CurrentTime;
        private Timer timer;

        public Tile Tile
        {
            set;
            get;
        }
        public Storage(Tile tile)
        {
            Tile = tile;

            // Create timer
//            timer = new Timer();
//            timer.Elapsed += new ElapsedEventHandler((source, e) => Tick());
//            timer.Interval = SPAWN_TIME;
        }

        public void SpawnCart()
        {
            // Psuedo code
            // Spawn a cart : Vak.Board.placeObject(this, Vak.Coords + new Point(1, 0)); // BaanVak always right of Loods
            RailTile tile = Tile.Board.Field.Get<RailTile>(Tile.Coords + Point.Right);

            if (tile?.IsOccupied() == true)
                return; // TODO
            else
            {
                Cart cart = new Cart(tile);
                tile.Contain = cart;
                tile.Board.MovsRef.Add(cart);
            }
        }

        public void Tick()
        {
            if (CurrentTime >= SPAWN_TIME / 1000f)
            {
                CurrentTime = 0;
                SpawnCart();
            }
            else
            {
                CurrentTime++;
            }
        }

        public void Run()
        {
//            timer.Enabled = true;
        }
    }
}

