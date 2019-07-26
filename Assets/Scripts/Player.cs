using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Task> Tasks = new List<Task>();
    PlayerAttribute PlayerAttribute;
    // Start is called before the first frame update
    void Start()
    {
        
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
