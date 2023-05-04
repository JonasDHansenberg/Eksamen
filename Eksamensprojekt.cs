using System;
using System.Collections.Generic;

class CookieClickerGame
{
    static void Main(string[] args)
    {
        int cookies = 0;
        int clickValue = 1;
        Shop shop = new Shop();

        Console.WriteLine("Welcome to Cookie Clicker!");
        Console.WriteLine("Click to earn cookies.");

        while (true)
        {
            Console.WriteLine("Cookies: " + cookies);
            Console.WriteLine("Click value: " + clickValue);
            Console.WriteLine("1. Click");
            Console.WriteLine("2. Upgrade click value");

            Console.WriteLine("Shop:");
            for (int i = 0; i < shop.items.Count; i++)
            {
                Item item = shop.items[i];
                Console.WriteLine((i + 3) + ". Buy " + item.name + " for " + item.price + " cookies (+" + item.value + " per second)");
            }

            Console.WriteLine((shop.items.Count + 3) + ". Quit");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (input == "1")
            {
                cookies += clickValue;
            }
            else if (input == "2")
            {
                int upgradeCost = clickValue * 10;
                if (cookies >= upgradeCost)
                {
                    cookies -= upgradeCost;
                    clickValue++;
                    Console.WriteLine("Click value upgraded to " + clickValue);
                }
                else
                {
                    Console.WriteLine("You need " + upgradeCost + " cookies to upgrade your click value.");
                }
            }
            else if (int.TryParse(input, out int choice))
            {
                if (choice >= 3 && choice <= shop.items.Count + 2)
                {
                    Item item = shop.items[choice - 3];
                    if (cookies >= item.price)
                    {
                        cookies -= item.price;
                        clickValue += item.value;
                        Console.WriteLine("You bought " + item.name + " for " + item.price + " cookies. Click value increased by " + item.value + ".");
                    }
                    else
                    {
                        Console.WriteLine("You need " + item.price + " cookies to buy " + item.name + ".");
                    }
                }
                else if (choice == shop.items.Count + 3)
                {
                    Console.WriteLine("Thanks for playing Cookie Clicker!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine();
        }
    }
}
