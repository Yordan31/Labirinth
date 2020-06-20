using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public struct PathFinderModel
    {
        public PathFinderModel(int x,int y,bool up=false,bool left = false, bool down = false, bool right = false)
        {
            this.X = x;
            this.Y = y;
            this.Up = up;
            this.Left = left;
            this.Right = right;

            this.Down = down;
        }//да имам качени няколко
        public int X { get; set; }
        public int Y { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public string ShowDirection()
        {
            if (Up) return "Up";
            if (Down) return "Down";
            if (Left) return "Left";
            if (Right) return "Right";

            return "Start";

        }

    }
}
