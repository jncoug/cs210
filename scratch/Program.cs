VendingMachine vm = new VendingMachine();
vm.populate();
vm.getList();

public class Item {
    private string name;
    private float price;

    public Item(string name, float price) {
        this.name = name;
        this.price = price;
    }

    public void showItem() {
        Console.WriteLine($"{name} -  ${price}");
        
    }

}

public class VendingMachine {

    private List<Item> items = new List<Item>();

    public VendingMachine() {
        Console.WriteLine("Hi, what is your order?");
        
    }

    public void getList() {
        Console.WriteLine("Here are the options");
        foreach(Item item in items) {
            item.showItem();
        }
    }

    public void populate() {
        items.Add(new Item("Cosmic Brownies", 1.00f));
        items.Add(new Item("Sprite", 1.50f));
    }
}