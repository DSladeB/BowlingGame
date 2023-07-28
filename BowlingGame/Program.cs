using BowlingGame;

Console.WriteLine("Hello, World!");


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
//ACT
Console.WriteLine($"Frame{9}, Score{score}");