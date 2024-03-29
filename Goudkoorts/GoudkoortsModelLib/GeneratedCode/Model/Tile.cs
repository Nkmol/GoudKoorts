﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.SqlTypes;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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

	    protected IContainObject _contain;
        public virtual IContainObject Contain { get { return _contain; } set { _contain = value; } } 

	    public Tile(Point coords, Board board = null)
	    {
            Coords = coords;
	        Board = board;
	    }



	    private static readonly Dictionary<char, Func<Point, Tile>> TileMapping = new Dictionary<char, Func<Point, Tile>>()
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
            switch (c)
            {
                case '~':
                    return new WaterTile(p);
                case '￩':
                case '￪':
                case '￫':
                case '￬':
                    return new SailTile(p, c);
                case '←':
                case '↑':
                case '→':
                case '↓':
                    return new RailTile(p, c);
                case 'L':
                    {
                        Tile tile = new Tile(p);
                        tile.Contain = new Storage(tile);
                        return tile;
                    }
                case 'S':
                case '>':
                case '<':
                    return new SwitchTile(p, c);
                case 'K':
                    return new PortTile(p);
                case 'B':
                    {
                        SailTile sail = new SailTile(p);
                        sail.Contain = new Boat(sail);
                        return sail;
                    }
                case 'G':
                    return new ParkTile(p);
                default:
                    return new Tile(p);
            }
	    }


        // Determines which sides to look
        // Also determines lookup priority
        protected static Point[] Sides = new Point[]
        {
            Point.Right, 
            Point.Up,
            Point.Down,
            Point.Left, 
        };

        // Look around itself to find next candidate Tiles
        public IEnumerable<T> NextAll<T>() where T : Tile
	    {
	        foreach (Point side in Sides)
	        {
	            Point newCoords = Coords + side;
	            if (!Board.IsInside(newCoords)) continue;

                Tile tile = Board.Field.Get(newCoords);
	            if (tile != null && tile is T)
	                yield return (T)tile;
	        }

	        yield return null;
	    }
    }
}

