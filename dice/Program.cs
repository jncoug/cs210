
void main() {
    Person person = new Person();
    Dice dice = new Dice();

}


public class Person {
    public int score = 0;
    public Person() 
    {
    }

    public void addScore() {

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

    public void rollDice() {
        for (int i = 0; i < 5; i++ ) {
            int value = random.Next(1,6);
            diceValues[i] = value;
        }
    }
}


