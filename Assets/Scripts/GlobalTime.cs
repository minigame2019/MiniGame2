using UnityEngine;
using System.Collections;

public class GlobalTime : MonoSingleton<GlobalTime>
{
    float CurrentTime = 0;
    private bool IsPaused;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += 1;
        Debug.Log(CurrentTime);
    }
}
