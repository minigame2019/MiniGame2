using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AllItem : MonoSingleton<AllItem>
{
    Dictionary<int, Item> ItemDict = new Dictionary<int, Item>();
    // Use this for initialization
    void LoadItemList()
    {
        Item item = new Item(1, "wood");
        ItemDict.Add(1, item);

    }

    public Item CreateItemById(int id)
    {
        if (!this.ItemDict.ContainsKey(id))
        {
            Debug.Log("Error!Not Contains Item which id == " + id.ToString());
            return null;
        }
        Item item = new Item(ItemDict[id]);
        return item;
    }
}
