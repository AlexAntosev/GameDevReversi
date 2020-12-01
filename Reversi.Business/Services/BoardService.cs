using System.Collections.Generic;
using Reversi.Business.Contracts.Constants;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class BoardService : IBoardService
    {
        public Dictionary<string, Disk> CreateBoard()
        {
            var board = new Dictionary<string, Disk>();
            
            var row = 'A';
            var column = 1;
            for (int i = 0; i < InitialSessionSettings.BoardRowDisksCount; i++)
            {
                for (int j = 0; j < InitialSessionSettings.BoardColumnDisksCount; j++)
                {
                    var boardPlace = $"{row}{column}";
                    board.Add(boardPlace, null);

                    row++;
                    column++;
                }
            }

            return board;
        }

        public void PrepareBoardToPlay(Dictionary<string, Disk> board)
        {
            board["D4"] = new Disk(Side.Dark);
            board["E5"] = new Disk(Side.Dark);
            board["D5"] = new Disk(Side.Light);
            board["E4"] = new Disk(Side.Light);
        }
    }
}