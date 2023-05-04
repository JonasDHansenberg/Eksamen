using System;
using System.Collections.Generic;

class Item
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public int Value { get; set; }

    public Item(string name, int cost, int value)
    {
        Name = name;
        Cost = cost;
        Value = value;
    }
}
