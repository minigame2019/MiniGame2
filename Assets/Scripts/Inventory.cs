using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    private List<InventorySlot> InventorySlots = new List<InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemAdded(Item item,int num)
    {
        Transform content = this.transform.GetChild(0).GetChild(0);
        foreach (Transform invtrans in content)
        {
            InventorySlot invslot = invtrans.GetComponent<InventorySlot>();
            if (invslot.IsStackable(item))
            {
                invslot.AddItem(num);
                return ;
            }
        }
        GameObject obj = Instantiate(new GameObject());
        obj.transform.parent = content;
        InventorySlot AddSlot = obj.AddComponent<InventorySlot>();
        AddSlot.Item = item;
        AddSlot.Count = num;
        AddSlot.SetText();
    }

    public void OnItemUsed(Item item,int num)
    {
        Transform content = this.transform.GetChild(0).GetChild(0);
        foreach (Transform invtrans in content)
        {
            InventorySlot invslot = invtrans.GetComponent<InventorySlot>();
            if (invslot.IsRemovable(item,num))
            {
                if (invslot.Count == num)
                {
                    InventorySlots.Remove(invslot);
                    invslot.transform.parent = null;
                    Destroy(invslot.gameObject);
                }
                else
                {
                    invslot.RemoveItem(num);                   
                }
                break;
            }
        }
    }
}
