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

	public class VaarVak : WaterVak
	{
        public VaarVak(Point coords, Board board = null) : base(coords, board)
        {
        }

        public virtual Boot Boot
		{
			get;
			set;
		}

	}
}

