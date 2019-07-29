using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    AreaManager areaM;
    float t = 0f;
    private void Awake()
    {
        areaM = GetComponent<AreaManager>();
        InitGame();
    }
    void InitGame()
    {
        areaM.SetupScene();
    }

    private void Update()
    {
        if (t < 20f)
        {
            t += Time.deltaTime;
        }
        else
        {
            areaM.BoardRefresh();
            t = 0f;
        }
    }
}
