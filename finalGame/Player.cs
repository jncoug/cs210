public class Player {
    
    string name;

    int health;
    int MAX_HEALTH;
    bool alive = true;

    int attack;

    int critChance;

    int sheildChance;

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

        attack = (20/numPlayers) + random.Next(3,10);
        critChance = random.Next(2,6);
        string critString = "poor";

        switch (critChance) {
            case 2:
                critString = "high";
                break;
            case 3:
                critString = "good";
                break;
            case 4:
                critString = "ok";
                break;
            case 5:
                critString = "low";
                break;
        }

        sheildChance = random.Next(2,6);
        string sheildString = "poor";

        switch (sheildChance) {
            case 2:
                sheildString = "high";
                break;
            case 3:
                sheildString = "good";
                break;
            case 4:
                sheildString = "ok";
                break;
            case 5:
                sheildString = "low";
                break;
        }

        Console.WriteLine($"{name}, you have {this.health} hp, your attack is {attack}, your critical hit rate is {critString}, and your defense level is {sheildString}.");

        Wait();
    }
    

    public int Attack() {

        Random r = new Random();
        int missChance = r.Next(1,7);
        if (drinkingCritPotion) {
            Console.WriteLine("Potion ATTACK!");
            drinkingCritPotion = false;
            if (missChance == 1) {
                
                return 0;
            }
            
            return attack*3;
        }

        
        int critLuck = r.Next(10, 110) / critChance;

        if (critLuck >= 20) {
            if (missChance == 1) {
                
                return 0;
            }
            else {
                Console.WriteLine("Critical Hit!");
            }
            return (attack*2);
        }
        else{
            if (missChance == 1) {
                
                return 0;
            }
            return attack;
        }
   
    }


    public bool TakeDamage(int damageDealt) {
        Random r = new Random();
        int sheild = r.Next(1,8);
        if (sheild>sheildChance) {
            damageDealt = (damageDealt/2);
            Console.WriteLine($"{name} blocked some damage with their shield!");
        }
        
        health-= damageDealt;
        
        Console.WriteLine($"{name} took {damageDealt} damage!");
        if (health <= 0) {
            
            Console.WriteLine($"No! {name} has fallen in battle. May their death be avenged!");
            alive = false;
            health = 0;
            
        }
        else {
            Console.WriteLine($"They have {health} HP");
        }
        return alive;
    } 

    public void Wait() {
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(".");
            Thread.Sleep(1000);
        }
    }

    public void Heal() {
        health+=15;
        if (health > MAX_HEALTH) {
            health = MAX_HEALTH;
        }
        Console.WriteLine($"{name} healed up! You now have {health} HP");
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
        Console.WriteLine($"{name} is ready to deal some serious damage!");
        Wait();
    }

    public bool IsDrinkingPotion() {
        return drinkingCritPotion;
    }
}