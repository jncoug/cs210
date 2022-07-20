public class Monster {

// create monster 1
    private List<string> monster1Art = new List<string>();

    int m1health = 125;
    int m1attack = 5;
    string m1name = "Gorgon the Slayer";

    // monster 2
    private List<string> monster2Art = new List<string>();

    int m2health = 95;
    int m2attack = 0;
    string m2name = "Fizz the Demon Newt";

    // monster 3
    private List<string> monster3Art = new List<string>();

    int m3health = 200;
    int m3attack = 0;
    string m3name = "FINAL BOSS: Puff the Dragon";

    int damage;

    int level = 1;

    public Monster() {
        monster1Art.Add("               |---.\\");
        monster1Art.Add("       ___     |    `");
        monster1Art.Add("      / .-\\  ./=)");
        monster1Art.Add("     |  |\"|_/\\/|");
        monster1Art.Add("     ;  |-;| /_|");
        monster1Art.Add("    / \\_| |/ \\ |");
        monster1Art.Add("   /      \\/\\( |");
        monster1Art.Add("   |   /  |` ) |");
        monster1Art.Add("   /   \\ _/    |");
        monster1Art.Add("  /--._/  \\    |");
        monster1Art.Add("  `/|)    |    /");
        monster1Art.Add("    /     |   |");
        monster1Art.Add("  .'      |   |");
        monster1Art.Add(" /         \\  |");
        monster1Art.Add("(_.-.__.__./  /");

        monster2Art.Add(" (_(");
        monster2Art.Add("  ('')");
        monster2Art.Add("_  \"\\ )>,_     .-->");
        monster2Art.Add("_>--w/((_ >,_.'");
        monster2Art.Add("   ///");
        monster2Art.Add("   \"`\"");


        monster3Art.Add("          |\\___/|");
        monster3Art.Add("         (,\\  /,)\\");
        monster3Art.Add("         /     /  \\");
        monster3Art.Add("        (@_^_@)/   \\");
        monster3Art.Add("         W//W_/     \\");
        monster3Art.Add("       (//) |        \\");
        monster3Art.Add("     (/ /) _|_ /   )  \\");
        monster3Art.Add("   (// /) '/,_ _ _/  (~^-.");
        monster3Art.Add(" (( // )) ,-{        _    `.");
        monster3Art.Add("(( /// ))  '/\\      /      |");
        monster3Art.Add("(( ///))     `.   {       }");
        monster3Art.Add(" ((/ ))    .----~-.\\   \\-'");
        monster3Art.Add("      ///.----..>   \\");
        monster3Art.Add("       ///-._ _  _ _}");



    }

    public void Show() {
        Console.WriteLine("");

        switch (level) {
            case 1:
                foreach (string art in monster1Art) {
                    Console.WriteLine($"{art}");
                    
                
                }
                Console.WriteLine(m1name);
                Console.WriteLine($"HP: {m1health}");
                Console.WriteLine("*****************");
                break;

            case 2:
                foreach (string art in monster2Art) {
                    Console.WriteLine($"{art}");
                    
                
                }
                Console.WriteLine(m2name);
                Console.WriteLine($"HP: {m2health}");
                Console.WriteLine("*****************");
                break;

            case 3:
                foreach (string art in monster3Art) {
                    Console.WriteLine($"{art}");
                    
                
                }
                Console.WriteLine(m3name);
                Console.WriteLine($"HP: {m3health}");
                Console.WriteLine("*****************");
                break;

            default:
                Console.WriteLine("New monster art needs to be created");
                break;
        }
        
        
    }

     public void Wait() {
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(".");
            Thread.Sleep(1000);
        }
    }

    public void NextLevel() {
        if (level < 4) {
            Console.WriteLine("Congratulations! You've defeated a dangerous foe! Unfortunately, your journey is not yet through.");
            Wait();
            Console.WriteLine("A new foe appears!");
            

        }
        else {
            Console.WriteLine("You've destroyed the last foe!");
        }
        
    }

    public bool TakeDamage(int damage) {

       

        switch (level) {
            case 1:
               
                m1health-= damage;
                if (m1health <= 0) {
                    m1health = 0;
                    Show();
                    level++;
                    return false;
                }
                else {
                    Console.WriteLine($"The enemy has {m1health} HP remaining");
                    return true;
                }
                
                break;

            case 2:
                m2health-= damage;
                if (m2health <= 0) {
                    m2health = 0;
                    Show();
                    level++;
                    return false;
                }
                else {
                    Console.WriteLine($"The enemy has {m2health} HP remaining");
                    return true;
                }
                
                break;

            case 3:
                m3health-= damage;
                if (m3health <= 0) {
                    m3health = 0;
                    Show();
                    level++;
                    return false;
                }
                else {
                    Console.WriteLine($"The enemy has {m3health} HP remaining");
                    return true;
                }
                
                break;

            default:
                Console.WriteLine("New monster needs to be created");
                return false;
                break;
        }
    }

    public void DoRound() {
        
        Random r = new Random();
        switch (level) {
            case 1:
                damage = m1attack + r.Next(5,11);
                break;

            case 2:
                damage = m2attack + r.Next(5,18);
                break;

            case 3:
                damage = m3attack + r.Next(5,35);
                break;

            default:
                Console.WriteLine("New monster needs to be created");
                break;
        }
    }

    public int GetDamage() {
        return damage;
    }

    public int GetHealth() {
        switch (level) {
            case 1:
                return m1health;
                break;

            case 2:
                return m2health;
                break;

            default:
                Console.WriteLine("New monster needs to be created");
                return 0;
                break;
        }
    }

    public int GetLevel() {
        return level;
    }
    
}