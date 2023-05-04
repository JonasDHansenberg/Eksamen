using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
class Program
{
    static void Main(string[] args)
    {
        int cookies = 0;
        int clickValue = 1;
        Cookie[] cookiesArray = new Cookie[]
        {
            new Cookie("Chocolate chip", 1),
            new Cookie("Peanut butter", 2),
            new Cookie("Sugar", 3),
            new Cookie("Oatmeal raisin", 4),
            new Cookie("Snickerdoodle", 5),
        };

        Milk[] milkArray = new Milk[]
        {
        new Milk("Whole milk", 1.0, 1.0),
        new Milk("2% milk", 1.5, 1.05),
        new Milk("Skim milk", 2.0, 1.1),
        new Milk("Almond milk", 2.5, 1.15),
        new Milk("Soy milk", 3.0, 1.2),
    };

        Shop shop = new Shop();

        Console.WriteLine("Welcome to Cookie Clicker!");
        Console.WriteLine("Click to earn cookies.");

        while (true)
        {
            Console.WriteLine("You have " + cookies + " cookies. Your cookies per click value is " + clickValue + ".");
            Console.WriteLine("1. Click the cookie");
            Console.WriteLine("2. Auto-clicker");
            Console.WriteLine("3. Shop");
            Console.WriteLine("4. Quit");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (input == "1")
            {
                cookies += clickValue;
                Console.WriteLine("You clicked the cookie and gained " + clickValue + " cookies!");
            }
            else if (input == "2")
            {
                Console.WriteLine("Coming soon!");
            }
               else if (input == "3")
        {
            Console.WriteLine("Shop:");
            Console.WriteLine("1. Cookies");
            Console.WriteLine("2. Milk");

            input = Console.ReadLine();
            Console.WriteLine();

            if (input == "1")
            {
                for (int i = 0; i < cookiesArray.Length; i++)
                {
                    Cookie cookie = cookiesArray[i];
                    Console.WriteLine((i + 1) + ". " + cookie.Name + " (+" + cookie.Value + " cookies per click)");
                }

                Console.WriteLine("Which cookie do you want to buy? (enter cookie number or 0 to cancel)");
                input = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= cookiesArray.Length)
                {
                    Cookie cookie = cookiesArray[index - 1];
                    if (cookies >= cookie.Value)
                    {
                        cookies -= cookie.Value;
                        clickValue += cookie.Value;
                        Console.WriteLine("You bought a " + cookie.Name + " cookie. Your cookies per click value is now " + clickValue + ".");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough cookies to buy a " + cookie.Name + " cookie.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cookie number.");
                }
            }
            else if (input == "2")
            {
                for (int i = 0; i < milkArray.Length; i++)
                {
                    Milk milk = milkArray[i];
                    Console.WriteLine((i + 1) + ". " + milk.Name + " ($" + milk.Price + ", x" + milk.Multiplier + " cookies per click)");
                }

                Console.WriteLine("Which milk do you want to buy? (enter milk number or 0 to cancel)");
                input = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= milkArray.Length)
                {
                    Milk milk = milkArray[index - 1];
                    if (cookies >= milk.Price)
                    {
                        cookies -= milk.Price;
                        clickValue = (int)Math.Round(clickValue * milk.Multiplier);
                        Console.WriteLine("You bought " + milk.Name + ". Your cookies per click value is now " + clickValue + ".");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough cookies to buy " + milk.Name + ".");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid milk number.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
                Console.WriteLine();
            }
        }
    }
    public class Cookie
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Price { get; set; }
        public Cookie(string name, int value, int price)
        {
            Name = name;
            Value = value;
            Price = price;
        }
    }
    public class Milk
    {
        public string Name { get; set; }
        public double Multiplier { get; set; }
        public double Price { get; set; }
        public Milk(string name, double multiplier, double price)
        {
            Name = name;
            Multiplier = multiplier;
            Price = price;
        }
    }
    public class Shop
    {
        public List<Cookie> Cookies { get; set; }
        public List<Milk> Milk { get; set; }
        public Shop()
        {
            Cookies = new List<Cookie>();
            Milk = new List<Milk>();
        }
        public void AddCookie(Cookie cookie)
        {
            Cookies.Add(cookie);
        }
        public void AddMilk(Milk milk)
        {
            Milk.Add(milk);
        }
    }
}