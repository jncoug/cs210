public class Source {
    private string url;
    private string name;

    public Source(string name, string url = "") {
        this.url = url;
        this.name = name;
    }

    public string getName() {
        return name;
    }

    public string getURL() {
        return url;
    }

}