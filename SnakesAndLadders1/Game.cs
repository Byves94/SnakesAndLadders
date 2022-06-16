namespace SnakesAndLadders1
{
    class Game
    {
        public Position[][] Board { get; set; } = new Position[10][];
        public List<Player> Players { get; set; } = new List<Player>();
        public Game()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = new Position[10];
                for (int j = 0; j < Board[i].Length; j++)
                {
                    Board[i][j] = new Position();
                }
            }
            int boardPosition = 1;
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board[i].Length; j++)
                {
                    Board[i][j].PositionNumber = boardPosition;
                    boardPosition++;
                }
            }
        }
        public int BoardLength()
        {
            int boardLength = 0;
            for (int i = 0; i < Board.Length; i++)
            {
                boardLength += Board[i].Length;
            }
            return boardLength;
        }
        public void CreateSnakesAndLadders(int numOfSnakes, int numOfLadders)
        {
            if (numOfSnakes <= 10 && numOfLadders <= 10)
            {
                for (int i = 0; i < numOfSnakes; i++)
                {
                    int row = new Random().Next(10);
                    int column = new Random().Next(10);
                    int newPositionRow = new Random().Next(10);
                    int newPositionColumn = new Random().Next(10);
                    while (row == newPositionRow || row < newPositionRow || Board[row][column].IsSnake)
                    {
                        row = new Random().Next(10);
                        newPositionRow = new Random().Next(10);
                    }
                    Board[row][column].newPositionNumber = Board[newPositionRow][newPositionColumn].PositionNumber;
                    Board[row][column].IsSnake = true;
                }
                for (int i = 0; i < numOfLadders; i++)
                {
                    int row = new Random().Next(10);
                    int column = new Random().Next(10);
                    int newPositionRow = new Random().Next(10);
                    int newPositionColumn = new Random().Next(10);
                    while (row == newPositionRow || row > newPositionRow || (row == 0 && column == 0) || Board[row][column].IsSnake || Board[row][column].IsLadder)
                    {
                        row = new Random().Next(10);
                        newPositionRow = new Random().Next(10);
                    }
                    Board[row][column].newPositionNumber = Board[newPositionRow][newPositionColumn].PositionNumber;
                    Board[row][column].IsLadder = true;
                }
            }
            else throw new Exception("Cannot create more than 10 snakes or 10 ladders.");
        }
        public void Create2GoldPositions()
        {
            for (int i = 0; i < 2; i++)
            {
                int goldPositionRow = new Random().Next(10);
                int goldPositionColumn = new Random().Next(10);
                while (Board[goldPositionRow][goldPositionColumn].IsSnake || Board[goldPositionRow][goldPositionColumn].IsLadder)
                {
                    goldPositionRow = new Random().Next(10);
                    goldPositionColumn = new Random().Next(10);
                }
                Board[goldPositionRow][goldPositionColumn].IsGold = true;
            }
        }
        public void PlayersPositions()
        {
            Console.WriteLine("------------------");
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Name} position:{player.Position}");
            }
            Console.WriteLine("------------------");
        }
        public void CheckPosition(Player player)
        {
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board[i].Length; j++)
                {
                    if (player.Position == Board[i][j].PositionNumber)
                    {
                        if (Board[i][j].IsLadder)
                        {
                            Console.WriteLine($"{player.Name} has stepped on a ladder! Moved to {Board[i][j].newPositionNumber}");
                            player.Position = Board[i][j].newPositionNumber;
                        }
                        else if (Board[i][j].IsSnake)
                        {
                            Console.WriteLine($"{player.Name} has stepped on a snake! Moved to {Board[i][j].newPositionNumber}");
                            player.Position = Board[i][j].newPositionNumber;
                        }
                        else if (Board[i][j].IsGold)
                        {
                            Player otherPlayer = null!;
                            foreach (Player p in Players)
                            {
                                if (player != p)
                                    otherPlayer = p;
                            }
                            if (player.Position < otherPlayer.Position)
                            {
                                int temp = player.Position;
                                player.Position = otherPlayer.Position;
                                otherPlayer.Position = temp;
                                Console.WriteLine($"{player.Name} has stepped on a gold position! Switched position with {otherPlayer.Name} ({player.Name}:{player.Position}, {otherPlayer.Name}:{otherPlayer.Position})");
                            }
                            else
                                Console.WriteLine($"{player.Name} has stepped on a gold position! Already on lead so nothing happens");
                        }
                    }
                }
            }
        }
        

    }

}

