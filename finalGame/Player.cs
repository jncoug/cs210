public class Player {
    
    string name;

    int health;
    int MAX_HEALTH;
    Boolean alive = true;

    int attack;

    int critChance;

    bool drinkingCritPotion = false;

    public Player(string name, int health, int numPlayers) {
        MAX_HEALTH = health;
        this.health = health;
        this.name = name;
        Random random = new Random();

        int healthChange = random.Next(1,6);
        int healthUpOrDown = random.Next(1,3);

        if (healthUpOrDown == 1) {
            this.health-=healthChange;
        }
        else {
            this.health+=healthChange;
        }

        attack = (20/numPlayers) + random.Next(1,10);
        critChance = random.Next(2,6);
        string critString = "poor";

        switch (critChance) {
            case 2:
                critString = "low";
                break;
            case 3:
                critString = "good";
                break;
            case 4:
                critString = "high";
                break;
            case 5:
                critString = "very high";
                break;
        }

        Console.WriteLine($"{name}, you have {this.health} hp, your attack is {attack} and your critical rate is {critString}");

        Thread.Sleep(2000);
    }
    

    public int Attack() {
        
        if (drinkingCritPotion) {
            Console.WriteLine("Potion ATTACK!");
            drinkingCritPotion = false;
            return attack*3;
        }

        Random r = new Random();
        int critLuck = r.Next(30, 110) / critChance;

        if (critLuck >= 20) {
            Console.WriteLine("Critical Hit!");
            return (attack*2);
        }
        else{
            return attack;
        }
   
    }


    public void TakeDamage(int damageDealt) {
        health-= damageDealt;
        Console.WriteLine($"{name} took {damageDealt} damage!");
        if (health <= 0) {
            
            Console.WriteLine($"No! {name} had been destroyed in battle. May their his/her death be avenged!");
            alive = false;
        }
        else {
            Console.WriteLine($"They are still in this battle. They have {health} HP");
        }
    } 

    public void Wait() {
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(".");
            Thread.Sleep(500);
        }
    }

    public void Heal() {
        health+=10;
        if (health > MAX_HEALTH) {
            health = MAX_HEALTH;
        }
    }

    public void DisplayInfo() {
        Console.WriteLine($"{name} | {health}");
    }

    public string GetName() {
        return name;
    }

    public int GetHealth() {
        return health;
    }

    public int GetAttack() {
        return attack;
    }

    public bool IsAlive() {
        return alive;
    }

    public void DrinkPotion() {
        drinkingCritPotion = true;
    }

    public bool IsDrinkingPotion() {
        return drinkingCritPotion;
    }
}