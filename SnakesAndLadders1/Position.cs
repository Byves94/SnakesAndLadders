using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders1
{
    internal class Position
    {
        public bool IsSnake { get; set; } = false;
        public bool IsLadder { get; set; } = false;
        public bool ContainPlayer { get; set; } = false;
        public bool IsGold { get; set; } = false;
        public int PositionNumber { get; set; }
        public int newPositionNumber { get; set; }
        public string PositionState()
        {
            if (IsSnake)
                return $"snaketo{newPositionNumber}";
            else if (IsLadder)
                return $"ladderto{newPositionNumber}";
            else if (IsGold)
                return "gold";
            else
                return "normal";
        }
    }
}
