class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException

        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");

        manager.PrintAllItems();

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.
        // Part Three: Use ItemManager<Fruit>
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();

        fruitManager.AddItem(new Fruit("Apple"));
        fruitManager.AddItem(new Fruit("Banana"));
        fruitManager.AddItem(new Fruit("Grapes"));

        Console.WriteLine("\nFruit List:");
        fruitManager.PrintAllItems();


        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
        IItemManager managerInterface = new ItemManager();
        managerInterface.AddItem("Orange");
        managerInterface.PrintAllItems(); // Orange
        managerInterface.RemoveItem("Orange");
        managerInterface.PrintAllItems(); // empty

        IItemManager<Fruit> fruitManagerInterface = new ItemManager<Fruit>();
        fruitManagerInterface.AddItem(new Fruit("Mango"));
        fruitManagerInterface.PrintAllItems(); // Mango

    }
}

public class ItemManager : IItemManager
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    // Part Two: Implement the RemoveItem method
    // TODO: Implement this method
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item} removed.");
        }
        else
        {
            Console.WriteLine($"{item} not found.");
        }
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items = new List<string>();
    }
}

public class ItemManager<T> : IItemManager<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void RemoveItem(T item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item} removed.");
        }
        else
        {
            Console.WriteLine($"{item} not found.");
        }
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items = new List<T>();
    }
}


public class Fruit
{
    public string Name { get; set; }

    public Fruit(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

public interface IItemManager
{
    void AddItem(string item);
    void RemoveItem(string item);
    void PrintAllItems();
    void ClearAllItems();
}

public interface IItemManager<T>
{
    void AddItem(T item);
    void RemoveItem(T item);
    void PrintAllItems();
    void ClearAllItems();
}