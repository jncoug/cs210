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
        }
    }

    public void DoOutputs() {
        if (monster.GetLevel() == 4) {
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
            Thread.Sleep(500);
        }
    }

    

    public void EndGame() {
        
    }
}