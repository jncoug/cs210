public class Quote {
    private string quote;
    private string author;
    private Source source;

    public Quote(string quote, string author, Source source) {

        this.quote = quote;
        this.author = author;
        this.source = source;
        

    }

    public bool hasAuthor(string authorName) {
        if (author.ToUpper().Contains(authorName.ToUpper())) {
            return true;
        }
        return false;
        
    }

    public string getQuote() {
        string url = source.getURL();
        url = url != "" ? $"[{url}]" : "";

        return $"\"{quote}\"\n{author} - {source.getName()} {url}";
    }
}