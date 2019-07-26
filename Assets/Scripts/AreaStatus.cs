using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using UnityEngine;
using UnityEngine.UI;
public class AreaStatus : MonoBehaviour
{
    public int status = 0;

    public Text statusText;
    public int numWood = 0;
    public int numIron = 0;
    public int numFood = 0;


    /// <summary>
    /// 参数为各种可能的status的权重
    /// </summary>
    int RandStatus(int w_empty = 1, int w_wood = 0, int w_iron = 0, int w_food = 0)
    {
        byte[] buffer = Guid.NewGuid().ToByteArray();
        int seed = BitConverter.ToInt32(buffer, 0);
        System.Random random = new System.Random(seed);
        int w_sum = w_empty + w_wood + w_iron + w_food;
        int result = random.Next(1, w_sum);
        if(result<=w_empty)
        {
            return 0;
        }
        result -= w_empty;
        if (result <= w_wood)
        {
            return 1;
        }
        result -= w_wood;
        if (result <= w_iron)
        {
            return 2;
        }
        result -= w_iron;
        if (result <= w_food)
        {
            return 3;
        }
        result -= w_food;
        return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        statusText = GetComponent<Text>();
        SetStatus(RandStatus(40,10,10,10));
    }
    
    /// <summary>
    /// 设置区域资源
    /// </summary>
    void SetResource(int wood = 0, int iron = 0, int food = 0)
    {
        numWood = wood;
        numIron = iron;
        numFood = food;
    }

    void GetResource(int wood = 0, int iron = 0, int food = 0)
    {
        if (numWood >= wood)
        {

        }
    }

    public void SetStatus(int s)
    {
        status = s;
        switch (status)
        {
            //empty
            case 0:
                statusText.text = "";
                SetResource(0, 0, 5);
                break;
            //wood
            case 1:
                statusText.text = "林";
                SetResource(100, 0, 20);
                break;
            //iron
            case 2:
                statusText.text = "矿";
                SetResource(0, 100, 0);
                break;
            case 3:
                statusText.text = "农";
                SetResource(0, 0, 200);
                break;
            default:
                statusText.text = "X";
                status = -1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
