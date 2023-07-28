using BowlingGame;

//ARRANGE
Game game = new Game();
game.SetRolls(new int[]
            {   0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10, 0 });

//ACT
int score = game.CalculateGame();

Console.WriteLine($"Frame{9}, Score{score}");