using System;
using System.Collections.Generic;
class Cookie
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Cookie(string name, int value)
    {
        Name = name;
        Value = value;
    }
}