namespace SnakesAndLadders1
{
    class Player
    {
        private string _name;
        public string Name { get { return _name; } set => _name = value.Substring(0, 1).ToUpper() + value.Substring(1); }
        public int Position { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 1;
        }
        public void Move(List<Dice> dices)
        {
            foreach (Dice dice in dices)
            {
                int diceRoll = dice.Roll();
                Position += diceRoll;
                Console.WriteLine($"Dice{dice.ID} has rolled {diceRoll}");
            }

        }
    }
}
