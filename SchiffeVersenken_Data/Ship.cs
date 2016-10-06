using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken.Data
{
    public enum Size { UBOOT = 2, ZERSTOERER = 3, KREUZER = 4, SCHLACHTSCHIFF = 5 } 
    public enum Direction { RIGHT, DOWN, LEFT, UP}

    public class Ship
    {

        private Position _StartPos;
        private List<Direction> _Directions;
        private Size _Size;
        private Direction _Dir;

        public Ship(Size size)
        {
            _Size = size;
            _Directions = new List<Direction>();
        }

        

        public Position StartPos
        {
            get
            {
                return _StartPos;
            }
            set { _StartPos = value; }
        }

        public List<Direction> Dirs
        {
            get { return _Directions; }
            set {
                _Directions = value;
            }
        }

        public int Size
        {
            get
            {
                return (int) _Size;
            }
        }
        
        public Direction Dir
        {
            get { return _Dir; }
            set { _Dir = value; }
        }
    }
}
