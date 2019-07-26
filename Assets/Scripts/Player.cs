using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<Task> Tasks = new List<Task>();
    PlayerAttribute PlayerAttribute;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnDoing();     
    }

    void OnDoing()
    {
        if (Tasks.Count != 0)
        {
            Task ToDo = Tasks[0];
            ToDo.OnDoing();
        }
    }

    void OnFinish()
    {

    }
}
