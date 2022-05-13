public class Program {
    static void Main() {

        // Source s = new Source("The Living Christ");
        Quote q = new Quote("Heaven is a place on Earth", "Pop Star", new Source("Song by Person"));
        Console.WriteLine(q.getQuote());

    }
    
}


