public class Director {

    private Game game = new Game();

    private Monster monster = new Monster();

    private Team team = new Team();

    private bool gameOver = false;
    private bool win = false;

    public Director() {

    }

    

    public void StartGame() {

        Console.WriteLine("Welcome to the Monster Game! Don't let him win!");
        Console.WriteLine("***********************************************");
        team.getPlayers();
        Console.WriteLine("An enemy approches!");
        Wait();
        monster.Show();
        team.ShowStats();
        

        while (!gameOver) {
            
            GetInputs();
            DoUpdates();
            DoOutputs();
            
        
        }
        EndGame();

    }

    public void GetInputs() {
        team.DoRound();
        Wait();
        monster.DoRound();
    }

    public void DoUpdates() {
        int damage = team.GetDamage();
        bool alive = monster.TakeDamage(damage);
        Wait();
        if (alive) {
            team.TakeDamage(monster.GetDamage());
        }
        else {
            monster.NextLevel();
            Wait();
        }
    }

    public void DoOutputs() {
        if (monster.GetLevel() == 4 || !team.IsPlaying()) {
            gameOver = true;
        }
        else {
            monster.Show();
            team.ShowStats();
        }
    }

    public void Wait() {
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(".");
            Thread.Sleep(1000);
        }
    }

    

    public void EndGame() {

        if (team.IsPlaying()) {
            Console.WriteLine("You've defeated all the enemys! Enjoy the treasure and may your days be long!");
        }
        else {
            Console.WriteLine("You were all defeated, better luck next time.");
        }
        Wait();
        Console.WriteLine("THE END");
        
    }
}