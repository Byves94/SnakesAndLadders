using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders1
{
    public class Dice
    {
        private static int id = 1;
        public int ID { get; set; }
        private int DiceResult { get; set; }
        public Dice()
        {
            ID = id;
            id++;
        }
        public int Roll()
        {
            Random random = new Random();
            DiceResult = random.Next(1,7);
            return DiceResult;
        }
    }
}
