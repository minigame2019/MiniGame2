using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class woodleft : MonoBehaviour
{

    public int num = 999;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeNum(int num)
    {
        text.text = "余量：" + num.ToString();
    }
}
