using System;
using System.Collections.Generic;
class Milk
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Multiplier { get; set; }

    public Milk(string name, double price, double multiplier)
    {
        Name = name;
        Price = price;
        Multiplier = multiplier;
    }
}
