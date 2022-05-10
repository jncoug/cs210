void main() {

    GameManager gm = new GameManager();
    gm.startGame();

}

main();

public class GameManager {

    List<Player> players = new List<Player>();
    bool gameOver = false;


    public GameManager()
    {
    }

    public int getPlayers() {
        int numPlayers = 0;

        Console.WriteLine("How many players would you like? (1-8)");
        numPlayers = int.Parse(Console.ReadLine());

        while (!(numPlayers <= 8 && numPlayers >= 1)) {
            Console.WriteLine("Oops, we need a number between 1 and 8");

            numPlayers = int.Parse(Console.ReadLine());

        }

        

        for (int i = 1; i <= numPlayers; i++) {
            Console.WriteLine($"Enter name for Player {i}:");
            string playerName = Console.ReadLine();
            players.Add(new Player(playerName));
        }

        return numPlayers;
    }

    public int getEndScore() {

        Console.WriteLine("What score would you like to play to? (400-3000)");
        int endScore = int.Parse(Console.ReadLine());


        while (!(endScore <= 3000 && endScore >= 400)) {
            Console.WriteLine("Oops, we need a finishing score between 400 and 3000");

            endScore = int.Parse(Console.ReadLine());

        }

        return endScore;

    }

    public void startGame() {
        Console.WriteLine("Welcome to the Hi-Low Game!");
        Console.WriteLine("*************************");
        
        Deck deck = new Deck();

        int endScore = getEndScore();
        int numPlayers = getPlayers();
        int playersFinished = 0;

      
        bool nextIsHigher;

        while(!gameOver) {

            deck.getNextCard();
            if (deck.nextCard > deck.currentCard) {
                nextIsHigher = true;
            }
            else {
                nextIsHigher = false;
            }
            Console.WriteLine($"The card is: {deck.currentCard}");

            foreach(Player player in players) {

                if (player.isPlaying) {

                    if ((numPlayers-1 == playersFinished && numPlayers != 1) || (numPlayers == playersFinished)) {
                        gameOver = true;
                        
                    }

                    else {
                        
                        Console.WriteLine($"{player.name} ({player.score} points): Higher or Lower? (h/l)");
                        player.guess(nextIsHigher);
                        
                        if (player.score <= 0) {
                            player.score = 0;
                            player.endGame();
                            playersFinished++;
                        }

                        else if (player.score >= endScore) {
                            gameOver = true;
                            
                            
                        }
                        
                    }
                }
            }
        }
        Console.WriteLine($"The card is: {deck.nextCard}");
        endGame();
    }

    public void endGame() {
        string winnerName = "";
        int winnerScore = 0;
        bool tie = false;

        foreach(Player player in players) {
            
            if (player.score > winnerScore) {
                winnerScore = player.score;
                winnerName = player.name;
                tie = false;
            }
            else if (player.score == winnerScore) {
                tie = true;
                winnerName += " and " + player.name;
            }

            if (player.score == 0) {
                Console.WriteLine($"{player.name}: You finished the game with 0 points.");
            }
            else {
                Console.WriteLine($"{player.name}: You finished the game with {player.score} points.");
            }
        }

        if (winnerScore == 0) {
            Console.WriteLine("Sorry! You lost. Better luck next time.");
        }
        else if (tie) {
            Console.WriteLine($"The winners are {winnerName} with a tie score of {winnerScore}!");
        }
        else {
            Console.WriteLine($"The winner is {winnerName} with a score of {winnerScore}!");
        }

    }
}


public class Player {

    public int score;
    public bool isPlaying = true;
    public string name;

    public Player(string playerName) 
    {
        name = playerName;
        score = 300;
    }

    public void guess(bool nextIsHigher) {
        
        int points;
        string input = Console.ReadLine();

        while (!(input == "h" || input == "l")) {
            Console.WriteLine("Oops, enter h or l to make a guess.");
            input = Console.ReadLine();

        }

        if (input == "h") {
            if (nextIsHigher) {
                points = 100;
            }
            else {
                points = -75;
            }
        }
        else { 
            if (nextIsHigher) {
                points = -75;
            }
            else {
                points = 100;
            }
        }

        score += points;
    }
    
    public void endGame() {
        
        isPlaying = false;
    }

}

public class Deck {
    public int currentCard;
    public int nextCard;
    Random random = new Random();
    

    public Deck()
    {
        nextCard = random.Next(1,13);

    }
    
    public void getNextCard() {
        currentCard = nextCard;
        while (nextCard == currentCard) {
            nextCard = random.Next(1,14);
        }

    }
}
