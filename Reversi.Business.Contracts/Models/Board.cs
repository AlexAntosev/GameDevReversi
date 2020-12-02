﻿using System.Collections.Generic;
using System.Linq;
using Reversi.Business.Contracts.Constants;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Board
    {
        public Dictionary<Position, Cell> Cells { get; set; }

        public Board()
        {
            CreateCells();
            PrepareBoardToPlay();
        }

        public void PlaceDisk(Position position, Color color)
        {
            GetCell(position).Disk = new Disk(color);
        }
        
        private Cell GetCell(Position position)
        {
            return Cells[position];
        }
        
        private void CreateCells()
        {
            Cells = new Dictionary<Position, Cell>();
            var row = 'A';
            
            for (var i = 0; i < InitialSessionSettings.BoardRowDisksCount; i++)
            {
                var column = '1';
                for (var j = 0; j < InitialSessionSettings.BoardColumnDisksCount; j++)
                {
                    var position = new Position(row, column);
                    Cells.Add(position, new Cell());
                    column++;
                }
                
                row++;
            }
        }

        private void PrepareBoardToPlay()
        {
            PlaceDisk(new Position('D', '4'), Color.Dark);
            PlaceDisk(new Position('E', '4'), Color.Light);
            PlaceDisk(new Position('D', '5'), Color.Light);
            PlaceDisk(new Position('E', '5'), Color.Dark);
        }
    }
}