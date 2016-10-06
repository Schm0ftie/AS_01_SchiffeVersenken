using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken.Data
{
    public enum Field { NONE = 0, SHIP = 1, HIT = -1, MISS = -2 }

    public class GameMap
    {
        private Random _Rand;
        private int[,] _Map;
        

        public int this[int x, int y]
        {
            get
            {
                return _Map[x, y];
            }
        }

        public int Height
        {
            get { return _Map.GetLength(0); }
        }

        public int Length
        {
            get { return _Map.GetLength(1); }
        }

        public GameMap()
        {
            _Rand = new Random();
            _Map = new int[10,20];
        }

        public GameMap(int height, int width){
            _Map = new int[height, width];
        }

        public void AddShip(Ship oShip) {
            int x = oShip.StartPos.X;
            int y = oShip.StartPos.Y;
            _Map[y, x] = 3;

            //TODO: Rest des Schiffes einzeichnen
        }
        
        private bool IsInbounds(Position oPos)
        {
            if (oPos.X < 0 || oPos.X >= this.Length || oPos.Y < 0 || oPos.Y >= this.Height)
                return false;
            return true;
        }

        public bool IsEmpty(Position oPos)
        {
            return IsInbounds(oPos) && _Map[oPos.Y, oPos.X] == (int)Field.NONE ;//&& !HasNeighbour(oPos, null);
        }

        public bool HasNeighbour(Position oPos, Position oOrigin)
        {
            Position oSource = (oOrigin == null) ? new Position(-100, -100) : oOrigin;

            Position oPosRight = new Position(oPos.X + 1, oPos.Y);
            Position oPosRightDown = new Position(oPos.X + 1, oPos.Y + 1);
            Position oPosDown = new Position(oPos.X, oPos.Y + 1);
            Position oPosDownLeft = new Position(oPos.X - 1, oPos.Y + 1);
            Position oPosLeft = new Position(oPos.X - 1, oPos.Y);
            Position oPosUpLeft = new Position(oPos.X - 1, oPos.Y - 1);
            Position oPosUp = new Position(oPos.X, oPos.Y - 1);
            Position oPosUpRight = new Position(oPos.X + 1, oPos.Y - 1);

            List<Position> oPosList = new List<Position>() { oPosRight, oPosRightDown, oPosDown, oPosDownLeft, oPosLeft, oPosUpLeft, oPosUp, oPosUpRight };

            foreach (Position oPosItem in oPosList)
            {
                if (oPosItem != oOrigin && !IsEmpty(oPosItem))
                    return true;
            }

            return false;
        }

        public bool IsShipPlaceable(Ship oShip)
        {
            if (!IsEmpty(oShip.StartPos))
                return false;
            if (HasNeighbour(oShip.StartPos, null))
                return false;
            //
            oShip.Dirs = GetAvailableDirections(oShip);
            if (oShip.Dirs.Count == 0)
                return false;
            return true;
        }

        private List<Direction> GetAvailableDirections(Ship oShip)
        {
            List<Direction> oDirList = new List<Direction>();

            if (CheckDirection(oShip, Direction.RIGHT))
                oDirList.Add(Direction.RIGHT);
            if (CheckDirection(oShip, Direction.DOWN))
                oDirList.Add(Direction.DOWN);
            if (CheckDirection(oShip, Direction.LEFT))
                oDirList.Add(Direction.LEFT);
            if (CheckDirection(oShip, Direction.UP))
                oDirList.Add(Direction.UP);

            return oDirList;
        }

        private bool CheckDirection(Ship oShip, Direction oDir)
        {
            Position oTempPos = oShip.StartPos;
            Position oLastPos;

            for (int i = 0; i < oShip.Size; i++)
            {
                oLastPos = oTempPos;
                oTempPos = oTempPos.Add(Position.ConvertDirection(oDir));
                _Map[oTempPos.Y, oTempPos.X] = 1;
                if (HasNeighbour(oTempPos, oLastPos))
                {
                    _Map[oTempPos.Y, oTempPos.X] = 8;
                    return false;
                }
            }
            oShip.Dirs.Add(oDir);
            return true;
        }
    }
}
