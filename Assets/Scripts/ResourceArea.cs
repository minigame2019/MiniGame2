using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Resource
{
    public Item Item;
    public float ConsumeTime;
}

public class ResourceArea : MonoBehaviour
{
    List<Resource> DetectedResources = new List<Resource>();
    float ConsumeTime;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    public List<Task> CreateTasks()
    {
        List<Task> Output = new List<Task>();
        Task Go = new Task();
        Go.Name = "前往";
        Go.IsLoop = false;
        Go.ConsumeTime = ConsumeTime;
        Output.Add(Go);

        Task Get = new Task();
        Get.Name = "采集";
        Get.IsLoop = true;
        Get.ConsumeTime = ConsumeTime;

        Output.Add(Get);

        Task Return = new Task();
        Return.Name = "返回";
        Return.ConsumeTime = ConsumeTime;
        Return.IsLoop = false;
        Output.Add(Return);

        return null;
    }
    */
}
