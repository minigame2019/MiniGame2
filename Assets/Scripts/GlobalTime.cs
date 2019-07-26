﻿using UnityEngine;
using System.Collections;

public class GlobalTime : MonoSingleton<GlobalTime>
{
    public float CurrentTime = 0;
    private bool IsPaused;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        //Debug.Log(CurrentTime);
    }
}
