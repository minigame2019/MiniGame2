﻿using UnityEngine;
using System.Collections;

public enum TaskStatus
{
    Waiting,
    Doing,
    Finished,
}
public class Task : MonoBehaviour
{
    public Player Player;

    public string Name;

    public bool IsLoop;

    public float ConsumeTime;//Time Per Loop

    public float StartTime;

    public TaskStatus TaskStatus = TaskStatus.Waiting;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        OnDoing();
    }

    public void OnFinish()
    {
        Debug.Log("Finish " + Name);
        if (IsLoop)
        {
            if (this.Name == "wood")
            {
                GameController.Instance.Inventory.OnItemAdded(new Item(1, "wood"), 1);
                ResLeft.Instance.curAS.numWood--;
            }
            else
            {
                if (this.Name == "iron") 
                {
                    GameController.Instance.Inventory.OnItemAdded(new Item(2, "iron"), 1);
                    ResLeft.Instance.curAS.numIron--;
                }
                else
                {
                    GameController.Instance.Inventory.OnItemAdded(new Item(3, "food"), 1);
                    ResLeft.Instance.curAS.numFood--;
                }
            }
            StartTime = GlobalTime.Instance.CurrentTime;
        }
        else
        {
            this.TaskStatus = TaskStatus.Finished;
            this.Player.StartNextTask();
        }
    }

    public void OnStart()
    {
        Debug.Log("Start " + Name);
        this.TaskStatus = TaskStatus.Doing;
        this.StartTime = GlobalTime.Instance.CurrentTime;
        Debug.Log(this.TaskStatus);
    }

    public void OnDoing()
    {
        if (this.TaskStatus != TaskStatus.Doing)
        {
            Debug.Log(this.TaskStatus);
            return;
        }
        Debug.Log("Doing " + Name);
        float PastTime = GlobalTime.Instance.CurrentTime - StartTime; ;
        Debug.Log(PastTime);
        if (PastTime >= ConsumeTime)
        {
            OnFinish();
        }
    }
    public void OnStop()
    {
        this.TaskStatus = TaskStatus.Finished;

    }
}
