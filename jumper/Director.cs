public class Director {

    private Game game = new Game();

    private Jumper jumper = new Jumper();

    private bool gameOver = false;
    private bool win = false;

    public Director() {

    }

    public void StartGame() {

        Console.WriteLine("Welcome to the Jumper Game! Don't let him fall!");
        Console.WriteLine("***********************************************");
        jumper.ShowJumper();

        game.ShowProgress();

        while (!gameOver && !win) {
            
            game.Guess();

            bool correctGuess = game.UpdateBoard();

            game.ShowProgress();

            if (!correctGuess) {
                gameOver = jumper.RemoveRow();
            }

            jumper.ShowJumper();

            win = game.CheckWin();
            
        
        }

        EndGame();

        
        
    }

    public void EndGame() {
        if (win) {
            Console.WriteLine("You Win!");
        }
        else {
            Console.WriteLine("Game Over!"); 
        }
        game.ShowWord();
    }
}