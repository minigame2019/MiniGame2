using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoSingleton<GameController>
{
    // Start is called before the first frame update
    List<Player> Players = new List<Player>();
    public Player CurrentPlayer;
    public Inventory Inventory;
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
        Debug.Log(CurrentPlayer);
        PersonCardUpdate();
        Transform InvTrans = transform.Find("InventoryPanel").GetChild(0);
        Inventory = InvTrans.GetComponent<Inventory>();
        
        
    }

    public void StopAllTask()
    {
        CurrentPlayer.StopTask();
    }
    public void CreateAllTask(string resname)
    {
        print("create all");
        Task t1 = this.gameObject.AddComponent<Task>();

        Debug.Log(t1);
        t1.Name = "Go";
        t1.IsLoop = false;
        t1.ConsumeTime = 1;
        t1.Player = CurrentPlayer;

        this.CurrentPlayer.Tasks.Add(t1);

        Task t2 = this.gameObject.AddComponent<Task>();
        t2.Name = resname;
        t2.IsLoop = true;
        t2.ConsumeTime = 1;
        t2.Player = CurrentPlayer;

        this.CurrentPlayer.Tasks.Add(t2);
        Task t3 = this.gameObject.AddComponent<Task>();
        t3.Name = "Return";
        t3.IsLoop = false;
        t3.ConsumeTime = 1;
        t3.Player = CurrentPlayer;
        this.CurrentPlayer.Tasks.Add(t3);
        this.CurrentPlayer.StartNextTask();
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

    }

    public Task CreateTask(string name, Player player, bool isloop, float consumetime)
    {
        Task t1 = this.gameObject.AddComponent<Task>();
        t1.Name = name;
        t1.IsLoop = isloop;
        t1.ConsumeTime = consumetime;
        t1.Player = player;
        return t1;
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
