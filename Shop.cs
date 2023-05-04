using System;
using System.Collections.Generic;

class Shop
{
    public List<Item> items;

    public Shop()
    {
        items = new Item[]
        {
            new Item("Cursor", 10, 1),
            new Item("Grandma", 50, 5),
            new Item("Farm", 250, 20),
            new Item("Mine", 1000, 80),
            new Item("Factory", 5000, 400),
            new Item("Bank", 25000, 2000),
            new Item("Temple", 100000, 10000),
            new Item("Wizard Tower", 500000, 50000),
            new Item("Shipment", 1000000, 200000),
            new Item("Alchemy Lab", 5000000, 1000000),
            new Item("Portal", 100000000, 50000000),
            new Item("Time Machine", 5000000000, 200000000),
            new Item("Antimatter Condenser", 100000000000, 10000000000),
        };    
      
    }
    public void DisplayItems()
    {
        Console.WriteLine("Items for sale:");
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            Console.WriteLine((i + 1) + ". " + item.name + " (Cost: " + item.cost + " cookies, Value: " + item.value + " cookies/sec)");
        }
    }

    public bool BuyItem(int index, ref int cookies, ref int cookiesPerSecond)
    {
        if (index >= 0 && index < items.Count)
        {
            Item item = items[index];
            if (cookies >= item.cost)
            {
                cookies -= item.cost;
                cookiesPerSecond += item.value;
                items.RemoveAt(index);
                Console.WriteLine("You bought " + item.name + " for " + item.cost + " cookies!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough cookies to buy " + item.name + ".");
            }
        }
        else
        {
            Console.WriteLine("Invalid item index.");
        }

        return false;
    }
}
