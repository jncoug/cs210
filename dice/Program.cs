
void main() {

    GameManager gm = new GameManager();
    gm.startGame();

}

main();

public class GameManager {

    List<Person> players = new List<Person>();
    bool gameOver = false;


    public GameManager()
    {
    }

    public int getPlayers() {

        Console.WriteLine("How many players would you like?");

        int numPlayers = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numPlayers; i++) {
            Console.WriteLine($"Enter name for Player {i}:");
            string playerName = Console.ReadLine();
            players.Add(new Person(playerName));
        }

        return numPlayers;
    }

    public void startGame() {
        Console.WriteLine("Welcome to the Dice Game!");
        Console.WriteLine("*************************");
        
        int numPlayers = getPlayers();
        int playersFinished = 0;

        string input;
        int highscore = 0;

        while(!gameOver) {

            foreach(Person player in players) {

                if (player.isPlaying) {

                    if (numPlayers-1 == playersFinished && player.score == highscore) {
                        gameOver = true;
                        endGame();
                    }

                    else {

                        Console.WriteLine($"{player.name} ({player.score} points): Would you like to roll the dice? (y/n)");
                        input = Console.ReadLine();
                        if (input == "y") {
                            int points = player.rollDice();
                            if (points == 0) {
                                playersFinished++;
                            }
                            else if (player.score > highscore) {
                                highscore = player.score;
                            }
                        }
                        else {
                            player.endGame();
                            playersFinished++;
                        }

                        if (numPlayers-1 == playersFinished && player.score > highscore) {
                            gameOver = true;
                            endGame();
                        }

                    }
                }
            }

            if (playersFinished == numPlayers) {
                    gameOver = true;
                    endGame();
            }
        }
    }

    public void endGame() {
        string winnerName = "";
        int winnerScore = 0;

        foreach(Person player in players) {
            
            if (player.score > winnerScore) {
                winnerScore = player.score;
                winnerName = player.name;
            }
        }

        Console.WriteLine($"The winner is {winnerName} with a score of {winnerScore}!");
    }
}


public class Person {

    public int score = 0;
    public bool isPlaying = true;
    public string name;

    public Person(string playerName) 
    {
        name = playerName;
    }

    public int rollDice() {
        Dice dice = new Dice();
        int points = dice.rollDice();
        if (points == 0) {
            score = 0;
            endGame();
        }
        else {
            score += points;
            Console.WriteLine($"Points: {points} Score: {score}");
        }

        return points;
    }
    
    public void endGame() {
        if (score == 0) {
            Console.WriteLine("No Luck! You finished the game with 0 points.");
        }
        else {
            Console.WriteLine($"You finished the game with {score} points.");
        }
        isPlaying = false;
    }

}

public class Dice {
    public List<int> diceValues = new List<int>(5);
    Random random = new Random();
    

    public Dice()
    {
        for (int i = 0; i < 5; i++ ) {
            diceValues.Add(0);
        
        }
    }

    public int rollDice() {
        int score = 0;
        string diceRollString = "";
        for (int i = 0; i < 5; i++ ) {
            int value = random.Next(1,6);
            diceValues[i] = value;
        }

        foreach (int value in diceValues) {
            diceRollString += value.ToString();
            diceRollString += " ";
            if (value == 1) {
                score += 100;
            }
            else if (value == 5) {
                score += 50;
            }
        }
        Console.WriteLine($"You rolled: {diceRollString}");

        return score;

    }
}




