public class Board {
    private List<Quote> quotes =  new List<Quote>();

    public Board() {

    }

    public void showQuotes() {
        foreach(Quote quote in quotes) {
            Console.WriteLine(quote.getQuote());
        }
    }

    public void addQuote(Quote quote) {
        quotes.Add(quote);
    }

    public void getRandomQuote() {
        random = new Random();
        int num = random.Next(0, quotes.Count);
        Console.WriteLine(quotes[num].getQuote());
    }
}


