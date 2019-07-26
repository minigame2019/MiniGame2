using UnityEngine;
using System.Collections;

public class Item
{
    private int ID;
    public string Name;

    public Item(int ID,string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }

    public Item(Item i)
    {
        this.ID = i.ID;
        this.Name=  i.Name;
    }
    public static bool operator == (Item i1,Item i2)
    {
        if (object.Equals(i1, null) || object.Equals(i2, null))
        {
            return object.Equals(i1, i2);
        }
        return i1.ID == i2.ID;
    }
    public static bool operator != (Item i1, Item   i2)
    {
        return !(i1 == i2); 
    }
}
