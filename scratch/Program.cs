public class Phone {

    private string phoneNumber;
    private List<string> textMessages = new List<string>();
    public Phone(string phoneNumber) {

        this.phoneNumber = phoneNumber;

    }

    public void placeCall(string numberToCall) {
        Console.WriteLine($"Dialing {numberToCall}...");
    }

    public void placeText(string numberToCall, string messageToSend) {
        Console.WriteLine($"Texting {numberToCall} this message: '{messageToSend}'");
    }

    public void saveText(string messageToSave) {
        Console.WriteLine("Saving message...");
    }

    public List<string> getTexts() {
        foreach(string text in textMessages) {
            Console.WriteLine(text);
        }
        return textMessages;
    }

    public string getNumber() {
        Console.WriteLine(phoneNumber) ;
        return phoneNumber;
        
    }
}

public class CameraPhone : Phone {
    List<string> images = new List<string>();

    public CameraPhone(string phoneNumber) : base(phoneNumber){

    }

    public void takePicture() {
        images.add("img");
    }
}