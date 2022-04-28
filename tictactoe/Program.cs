
// Set all of the variables up that we need
List<string> values = new List<string>();
for (int i = 1; i < 11; i++) {
    values.Add(i.ToString());
}
int turn = 2;
string barrier = "-+-+-";
bool gameover = false;


// show the list values in a gameboard form
void displayBoard() {
    Console.WriteLine($"{values[0]}|{values[1]}|{values[2]}");
    Console.WriteLine(barrier);
    Console.WriteLine($"{values[3]}|{values[4]}|{values[5]}");
    Console.WriteLine(barrier);
    Console.WriteLine($"{values[6]}|{values[7]}|{values[8]}");
    return;
}

// change the values of the list to reflect the choices of the players
void editValues(int turn) {
    string player;
    if (turn % 2 == 0) {
        player = "X";
    }
    else {
        player = "O";
    }

    int space=-1;
    Console.WriteLine($"Next move for {player}'s...");
    bool validinput = false;

    // make sure the input is valid
    while (!validinput || space==-1) {
        try {
            space = int.Parse(Console.ReadLine());
            if (values[space-1] == "X" || values[space-1] == "O") {
                throw new Exception();
            }
            else if (space-1 < 0 || space-1 > 9) {
                throw new Exception();
            }
            else {
                validinput = true;
            }
            
        } catch {
            Console.WriteLine("Oops! Please enter a valid input.");
        }
    }
    
    // enter X or O depending on the turn
    if (turn % 2 == 0) {
        values[space-1] = "X";
    }
    else {
        values[space-1] = "O";
    }

    return;

}

// check whether or not the game has been won
bool checkGameOver() {
    if (values[0] == values[1] && values[1] == values[2] || values[3] == values[4] && values[4] == values[5] || values[6] == values[7] && values[7] == values[8]
    || values[0] == values[3] && values[3] == values[6] || values[1] == values[4] && values[4] == values[7] || values[2] == values[5] && values[5] == values[8]
    || values[0] == values[4] && values[4] == values[8] || values[6] == values[4] && values[4] == values[2]) {
        return true;
    }
    else {
        return false;
    }
    
}

// this will be the game manager, calling all of the different functions
void main() {
    Console.WriteLine("Let's Play Tic-Tac-Toe");
    while (!gameover && turn < 11) {
        // display, ask, change, check for gameover
        displayBoard();
        editValues(turn);
        turn++;
        gameover = checkGameOver();

    }

    displayBoard();
    
    if (gameover) {

        if (turn % 2 == 0) {
            Console.WriteLine("Thanks for playing! O's Win!");
        }
        else {
            Console.WriteLine("Thanks for playing! X's Win!");
    }

    } 
    else {
        Console.WriteLine("Thanks for playing! It's a draw.");
    }
    
    return;
}

// start the program running
main();