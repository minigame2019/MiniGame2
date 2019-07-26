using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerAttribute: MonoBehaviour
{
    public int Hp = 1;
    public int Attack = 1;
    public int Defend = 1;
    public int Luck;
    public int Hunger = 1;
    public float Speed;
    public float Digger;
    public float Pressure;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Upd");
    }
}
