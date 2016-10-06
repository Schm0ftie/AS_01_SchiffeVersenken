﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SchiffeVersenken.Data;

namespace SchiffeVersenken.Logic
{
    public class LogicHandler
    {

        private GameMap _Map;
        private Random _Random;
        

        public LogicHandler()
        {
            _Map = new GameMap(10, 20);
            _Random = new Random();
            PopulateMap(_Map);
            Print();
            
        }

        public GameMap GetMap()
        {
            return _Map;
        }

        private void PopulateMap(GameMap oMap) {
            
            List<Ship> oShipList = GenerateShips();
            foreach(Ship oShip in oShipList)
            {
                oShip.StartPos = GetRandomLocation();
                while (!_Map.IsShipPlaceable(oShip))
                {
                    oShip.StartPos = GetRandomLocation();
                }
                _Map.AddShip(oShip);
            }
            
        }

        
        private List<Ship> GenerateShips()
        {
            List<Ship> oShipList = new List<Ship>() {
                new Ship(Size.SCHLACHTSCHIFF),
                new Ship(Size.KREUZER),
                new Ship(Size.KREUZER),
                new Ship(Size.ZERSTOERER),
                new Ship(Size.ZERSTOERER),
                new Ship(Size.ZERSTOERER),
                new Ship(Size.UBOOT),
                new Ship(Size.UBOOT),
                new Ship(Size.UBOOT),
                new Ship(Size.UBOOT)};
            return oShipList;
        }

        private Position GetRandomLocation()
        {
            int x = _Random.Next(0, _Map.Length);
            int y = _Random.Next(0, _Map.Height);
            return new Position(x, y);
        }

        private void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _Map.Length; i++)
            {
                for(int j = 0; j < _Map.Height; j++)
                {
                    sb.Append("[ " + _Map[i, j] + " ]");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}