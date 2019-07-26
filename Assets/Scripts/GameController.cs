using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoSingleton<GameController>
{
    // Start is called before the first frame update
    List<Player> Players = new List<Player>();
    Player CurrentPlayer;
    Inventory Inventory;
    List<ResourceArea> ResourceAreas = new List<ResourceArea>();
    GlobalTime GlobalTime;
    void Start()
    {
        GlobalTime =  GlobalTime.Instance;
        Transform BtnPanel = this.transform.Find("PersonCardsPanel/ButtonPanel");
        Debug.Log(BtnPanel);
        for (int i = 0;i < 5; i++)
        {
            string BtnName = "Player" + i.ToString() + "Btn";
            Transform BtnTrans = BtnPanel.Find(BtnName);
            Button Btn = BtnTrans.GetComponent<Button>();
            Player ToAdd = BtnTrans.gameObject.AddComponent<Player>();
            Players.Add(ToAdd);
            Btn.onClick.AddListener(delegate {CurrentPlayer = ToAdd; PersonCardUpdate(); });
        }
        CurrentPlayer = Players[0];
        PersonCardUpdate();
        Transform InvTrans = transform.Find("InventoryPanel").GetChild(0);
        Inventory = InvTrans.GetComponent<Inventory>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Item item = new Item(1, "Wood");
            this.Inventory.OnItemAdded(item,1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Item item = new Item(2, "Iron");
            this.Inventory.OnItemAdded(item, 1);
        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Item item = new Item(1, "Wood");
            this.Inventory.OnItemUsed(item, 1);
        }


        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Item item = new Item(2, "Iron");
            this.Inventory.OnItemUsed(item, 1);
        }
    }

    private void PersonCardUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Players[i] == CurrentPlayer)
            {
                //Update Person Attribute

            }
        }

    }

    private void MessageHistoryUpdate()
    {

    }

    private void InventoryAdded()
    {
        
    }

    private void InventoryValueChanged(Item item)
    {
        Transform InvPanel = this.transform.Find("InventoryPanel/Inventory");
        Transform ConTrans = InvPanel.GetChild(0).GetChild(0);
        foreach (Transform t in ConTrans)
        {
            if (t.GetComponent<InventorySlot>().ValueChanged)
            {
                t.GetComponent<InventorySlot>().SetText();
            }
        }
    }

    private void InventoryRemoved()
    {

    }



}
