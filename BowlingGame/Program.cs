using BowlingGame;

//ARRANGE
Game game = new Game();
game.SetRolls(new int[]
{   4, 3,
    7, 3,
    5, 2,
    8, 1,
    4, 6,
    2, 4,
    8, 0,
    8, 0,
    8, 2,
    10, 1, 7 });

//ACT
int score = game.CalculateGame();

Console.WriteLine($"Score: {score}");