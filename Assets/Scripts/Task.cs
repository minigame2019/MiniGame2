using UnityEngine;
using System.Collections;

public class Task : MonoBehaviour
{
    public Player Player;

    public string Name;

    public bool IsLoop;

    public float ConsumeTime;//Time Per Loop

    float LeftTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFinish()
    {
        if (IsLoop)
        {
            LeftTime = ConsumeTime;
        }
        else
        {

        }
    }

    public void OnDoing()
    {
        LeftTime -= Time.deltaTime;
        if (LeftTime <= 0)
        {
            OnFinish();
        }
    }
}
