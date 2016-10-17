﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Boot : iUpdateable
	{
        public readonly Point direction;
        public static int MAX_CARGO = 8;

        public bool Docked
        {
            get;
            set;
        }

        public VaarVak Vak
        {
            get;
            set;
        }

		public virtual int Cargo
		{
			get;
			private set;
		}

        public Boot(VaarVak vak)
        {
            direction = new Point(-1, 0); // Boat always moves from right to left.

            Vak = vak;
        }

        public bool addCargo()
        {
            if(Cargo >= MAX_CARGO)
                return false;

            Cargo++;

            return true;
        }

		public virtual void Update()
		{
            // Move Ship

			// Psuedo code
            // Get next VaarVak : Vak.Board.SetVak(this, Vak.Coords + direction);
		}

	}
}

