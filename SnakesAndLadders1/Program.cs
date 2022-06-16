namespace SnakesAndLadders1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            List<Dice> dices = new List<Dice>() { new Dice(), new Dice() };
            List<Player> players = new List<Player>();

            Console.WriteLine("Welcome to snakes and ladder game!");
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"Please enter player{i} name:");
                Player player = new Player(Console.ReadLine());
                players.Add(player);
            }
            game.Players.AddRange(players);
            game.CreateSnakesAndLadders(8, 9);
            game.Create2GoldPositions();

            string input;
            int turn = 0;
            bool inGame = true;

            
            Console.WriteLine();
            while (inGame)
            {
                if (turn > game.Players.Count - 1)
                    turn = 0;

                Player currentPlayer = players[turn];
                Console.WriteLine($"{currentPlayer.Name}'s turn");
                Console.WriteLine("click \"r\" to roll the dices,\"board\" to print the board, or type \"exit\" to exit game.");
                input = Console.ReadLine().ToLower().Trim();

                switch (input)
                {
                    case "r":
                        int prevPosition = currentPlayer.Position;
                        Console.WriteLine("------------------------");
                        Console.WriteLine($"{currentPlayer.Name}");
                        currentPlayer.Move(dices);
                        Console.WriteLine($"{currentPlayer.Name} moved from {prevPosition} to {currentPlayer.Position}");
                        game.CheckPosition(currentPlayer);
                        Console.WriteLine("------------------------");
                        if (turn == 1)
                            game.PlayersPositions();
                        if (currentPlayer.Position >= game.BoardLength())
                        {
                            Console.WriteLine($"{currentPlayer.Name} has won!");
                            inGame = false;
                            break;
                        }
                        else
                        {
                            turn++;
                            break;
                        }
                    case "board":
                        Console.WriteLine("------------------------");
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                Console.Write($"{game.Board[i][j].PositionNumber}({game.Board[i][j].PositionState()}),");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("------------------------");
                        break;
                    case "exit":
                        Console.WriteLine("Exiting game.");
                        inGame = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
        }
    }
}