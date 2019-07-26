using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class MessageHistory : MonoBehaviour
{
    public Font Font;
    List<string> Msgs = new List<string>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AddMessage("123");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AddMessage("321");
        }
    }

    void AddMessage(string msg)
    {
        this.Msgs.Add(msg);
        Transform transform = this.transform.GetChild(0).GetChild(0);
        GameObject obj = Instantiate(new GameObject());
        Text t = obj.AddComponent<Text>();
        t.font = Font;

        
        t.text = msg;
        obj.transform.parent = transform;
    }
}
