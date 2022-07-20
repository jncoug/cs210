public class Team
{
    int teamDamage;

    bool isPlaying = true;
    int TEAM_HEALTH = 150;

    int healPotions = 4;

    int criticalPotions = 3;

    int playersLeft;
    bool drinkingCritPotion = false;

    private List<Player> players = new List<Player>();
    public Team() {
        
    }

    public void getPlayers() {

        Console.WriteLine("How many players would you like?");

        int numPlayers = int.Parse(Console.ReadLine());

        playersLeft=numPlayers;

        int playerHealth = TEAM_HEALTH/numPlayers;

        for (int i = 1; i <= numPlayers; i++) {
            Console.WriteLine($"Enter name for Player {i}:");
            string playerName = Console.ReadLine();
            players.Add(new Player(playerName, playerHealth, numPlayers));
        }
        

    }

    public void Heal() {
        Console.WriteLine("Which player would you like to heal (+15 health)?");
        int i = 1;
        foreach(Player player in players) {
            if (player.IsAlive()) {
                Console.WriteLine($"{player.GetName()} [{i}]");
                i++;
            }
        }
        string input = Console.ReadLine();

        players[int.Parse(input)-1].Heal();
        
    }

    public void DrinkCritPotion() {

        Console.WriteLine("Which player would you like to drink the critical potion (guaranteed x3 critical hit)?");
        int i = 1;
        foreach(Player player in players) {
            if (player.IsAlive()) {
                Console.WriteLine($"{player.GetName()} ({player.GetAttack()} attack) [{i}]");
                i++;
            }
        }
        string input = Console.ReadLine();

        players[int.Parse(input)-1].DrinkPotion();

    }

    public void DoRound() {
        //pre round moves (drink a potion)
        Console.WriteLine($"You have {healPotions} heal potions and {criticalPotions} critical hit potions. Use one: [h]eal, [c]ritical, or [f]ight: ");
        string input = Console.ReadLine();

        switch (input) {
            case "h":
                if (healPotions>0) {
                    healPotions--;
                    Heal();
                }
                else {
                    Console.WriteLine("You don't have any more healing potions");
                }
                break;
            case "c":
                if (criticalPotions>0) {
                    criticalPotions--;
                    drinkingCritPotion = true;
                    DrinkCritPotion();
                    
                }
                else {
                    Console.WriteLine("You don't have any more critical potions");
                }
                break;
        }
        
        // each player attacks
        Console.WriteLine("You are now attacking!");
        int damageToDo = 0;
        foreach(Player player in players) {
            if (player.IsAlive()) {

                Console.WriteLine($"{player.GetName()} is attacking");
                Wait();
                int playerDamage = player.Attack();
                damageToDo+=playerDamage;
                if (playerDamage == 0) {
                    Console.WriteLine("Oh no! you missed!");
                }
                else {
                    Console.WriteLine($"The enemy was dealt {playerDamage} damage by {player.GetName()}.");
                }
                
            }
            

        }

        teamDamage = damageToDo;
    }

    public void ShowStats() {
        foreach (Player player in players) {
            Console.WriteLine($"{player.GetName()} | HP: {player.GetHealth()}");
        }
    }

    public void Wait() {
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(".");
            Thread.Sleep(1000);
        }
    }

    public int GetDamage() {
        return teamDamage;
    }

    public void TakeDamage(int damageDealt) {
        Console.WriteLine("The monster is now attacking");
        Wait();
        Random r = new Random();

        List<Player> playersToHit = new List<Player>();

        foreach(Player player in players) {
                if (player.IsAlive()) {
                    playersToHit.Add(player);
                }
            }

        if (playersLeft>2) {
            
            bool alive = playersToHit[r.Next(0,playersToHit.Count)].TakeDamage(damageDealt);
            if (!alive) {
                playersLeft--;
            }
            Wait();
            alive = playersToHit[r.Next(0,playersToHit.Count)].TakeDamage(damageDealt);
            if (!alive) {
                playersLeft--;
            }
            Wait();
        }
        else {
            bool alive = playersToHit[r.Next(0,playersToHit.Count)].TakeDamage(damageDealt);
            if (!alive) {
                playersLeft--;
            }
            Wait();
        }

        if (playersLeft == 0) {
            isPlaying = false;
        }
    }

    public bool IsPlaying() {
        return isPlaying;
    }


}