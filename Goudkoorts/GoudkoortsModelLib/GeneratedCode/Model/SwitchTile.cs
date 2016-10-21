﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

    public class SwitchTile : RailTile
    {
        public int DirectionVertical;

        public SwitchTile(Point coords, Board board = null) : base(coords, board)
        {
            this.Coords = coords;
            this.Board = board;

            DirectionVertical = 1;
            
        }

        public void SetOppositeDirection()
        {
            DirectionVertical *= -1;
        }

        public bool isOccupied()
        {
            return (this.Cart != null);
        }

    }
}

