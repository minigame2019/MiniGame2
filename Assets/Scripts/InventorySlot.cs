using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Item Item;
    public int Count = 0;
    public bool ValueChanged;

    public bool IsStackable(Item item)
    {
        Debug.Log("IsStackable");
        Debug.Log(item);
        Debug.Log(this.Item);
        Debug.Log(item==this.Item);
        if (item == this.Item)
        {
            return true;
        }
        return false;
    }

    public bool IsRemovable(Item item, int num)
    {
        if (item == this.Item)
        {
            if (Count >= num)
            {
                return true;
            }
        }
        return false;
    }

    public void SetText()
    {
        Text t = this.GetComponent<Text>();
        if (t == null)
        {
            Text a = this.gameObject.AddComponent<Text>();
            a.text = this.Item.Name + ":" + this.Count.ToString();
        }
        else
        {
            t.text = this.Item.Name + ":" + this.Count.ToString();
        }
    }

    public void AddItem(int num)
    {
        this.Count += num;
        this.SetText();
        this.ValueChanged = true;
    }

    public void RemoveItem(int num)
    {
        this.Count -= num;
        this.SetText();
        this.ValueChanged = true;

    }
}
