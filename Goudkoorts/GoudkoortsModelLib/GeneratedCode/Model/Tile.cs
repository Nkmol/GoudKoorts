﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.Drawing;

	public class Tile
	{
       
        public Point Coords { get; set; }

        public Board Board { get; set; }

	    protected Object _contain;
        public virtual Object Contain { get { return _contain; } set { _contain = value; } } // TODO: Change to Interface of object that can go inside a tile? PlaceAbleTileObject?

	    public Tile(Point coords, Board board = null)
	    {
            Coords = coords;
	        Board = board;
	    }


	    private static readonly Dictionary<char, Func<Point, Tile>> tileMapping = new Dictionary<char, Func<Point, Tile>>()
	    {
            { ' ', p => new Tile(p) },
            { '~', p => new WaterTile(p) },
            { '-', p => new SailTile(p) },
            { '.', p => new RailTile(p) },
            { 'L', p =>
                {
                    Tile tile = new Tile(p);
                    tile.Contain = new Storage(tile);
                    return tile;
                }
            },
            { 'S', p => new SwitchTile(p) },
            { 'K', p => new PortTile(p) },
            { 'B', p =>
                {
                    SailTile sail = new SailTile(p);
                    sail.Contain = new Boat(sail);
                    return sail;
                }
            },
            { 'G', p => new ParkTile(p) },
        };

	    public static Tile Create(char c, Point p)
	    {
	        c = Char.ToUpper(c);
	        return tileMapping[c](p);
	    }


	}
}

