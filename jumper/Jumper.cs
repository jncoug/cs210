public class Jumper {

    private List<string> jumperArt = new List<string>();

    public Jumper() {
        jumperArt.Add("  ___");
        jumperArt.Add(" /___\\");
        jumperArt.Add(" \\   /");
        jumperArt.Add("  \\ /");
        jumperArt.Add("   O");
        jumperArt.Add("  /|\\  ");
        jumperArt.Add("  / \\");

    }

    public void ShowJumper() {
        Console.WriteLine("");
        foreach (string art in jumperArt) {
            Console.WriteLine($"{art}");
        }
    }

    public bool RemoveRow() {
        jumperArt.RemoveAt(0);
        if (jumperArt.Count < 4) {
            jumperArt[0] = "   X";
            return true;
        }
        return false;
    }
}