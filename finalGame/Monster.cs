public class Monster {

    private List<string> monster1Art = new List<string>();

    int m1health = 150;
    int m1attack = 10;

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

    }

    public void Show() {
        Console.WriteLine("");

        switch (level) {
            case 1:
                foreach (string art in monster1Art) {
                    Console.WriteLine($"{art}");
                    
                
                }
                Console.WriteLine($"HP: {m1health}");
                break;
            default:
                Console.WriteLine("New monster needs to be created");
                break;
        }
        
        
    }

     public void Wait() {
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(".");
            Thread.Sleep(500);
        }
    }

    public void NextLevel() {
        if (level < 4) {
            Console.WriteLine("Congratulations! You've defeated a dangerous foe! Unfortunatley, your journey is not yet through.");
            

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
                    level++;
                    return false;
                }
                else {
                    Console.WriteLine($"The enemy has {m1health} HP remaining");
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
                damage = m1attack + r.Next(1,5);
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