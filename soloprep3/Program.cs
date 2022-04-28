// See https://aka.ms/new-console-template for more information

Random random = new Random();

int guess;

int guesses = 0;

bool playing = true;

while (playing) {

    int num = random.Next(1,100);
    // Console.WriteLine(num);

    Console.WriteLine("Guess the number between 1 and a 100!");
    Console.WriteLine("Make a guess...");
    guess = int.Parse(Console.ReadLine());

    while (num != guess) {

        guesses++;

        if (guess > num) {
            Console.WriteLine("Guess lower...");
            guess = int.Parse(Console.ReadLine());
        }

        else if (guess < num) {
            Console.WriteLine("Guess higher...");
            guess = int.Parse(Console.ReadLine());
        }

    }

    Console.WriteLine($"Correct! It took you {guesses} guesses.");

    guesses = 0;

    Console.WriteLine("Would you like to play again? (y/n)");

    string answer = Console.ReadLine();
    
    if (answer != "y") {
        playing = false;
        Console.WriteLine("Thanks for playing!");
    }
}
