using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public List<Task> Tasks = new List<Task>();
    public PlayerAttribute PlayerAttribute;


    // Start is called before the first frame update
    void Start()
    {
        PlayerAttribute = new PlayerAttribute();
        Debug.Log("Player Start");
    }

    // Update is called once per frame
    void Update()
    {
        OnDoing();
        if (IsAllFinished())
        {
            foreach (Task t in Tasks)
            {
                Destroy(t);               
            }
            this.Tasks.Clear();
        }

        PersonCardUpdate();
    }

    void PersonCardUpdate()
    {
        Player CurrentPlayer = GameController.Instance.CurrentPlayer;
        Transform trans = GameController.Instance.transform.Find("PersonCardsPanel/AttributePanel");
        if (CurrentPlayer != this)
        {
            return ;
        }
        Transform HpHunger = trans.GetChild(0);
        Transform Hp = HpHunger.GetChild(0);
        Text t = Hp.GetComponent<Text>();
        t.text = CurrentPlayer.PlayerAttribute.Hp.ToString();
        Transform Hunger = HpHunger.GetChild(1);
        t = Hunger.GetComponent<Text>();
        t.text = CurrentPlayer.PlayerAttribute.Hunger.ToString();

        Transform AtkDef =trans.GetChild(1);
        Transform Atk = AtkDef.GetChild(0);
        t = Atk.GetComponent<Text>();
        t.text = CurrentPlayer.PlayerAttribute.Attack.ToString();

        Transform Def = AtkDef.GetChild(1);
        t = Def.GetComponent<Text>();
        t.text = CurrentPlayer.PlayerAttribute.Defend.ToString();
    }
    void OnDoing()
    {
       
        foreach (Task t in Tasks)
        {
            
        }
    }

    public void StartNextTask()
    {
        foreach (Task t in Tasks)
        {
            if (t.TaskStatus == TaskStatus.Finished)
            {
                continue;
            }
            t.OnStart();
            return;
        }
    }

    public bool IsAllFinished()
    {
        foreach (Task t in Tasks)
        {
            if (t.TaskStatus != TaskStatus.Finished)
            {
                return false;
            }
        }
        return true;
    }

    public void AddTask(Task task)
    {
        this.Tasks.Add(task);
    }

    public void StopTask()
    {
        foreach(Task t in Tasks)
        {
            if (t.Name != "Return")
            {
                t.OnStop();
            }
        }
        StartNextTask();
    }
}
