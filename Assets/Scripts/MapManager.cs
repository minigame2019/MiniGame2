using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    AreaManager areaM;

    private void Awake()
    {
        areaM = GetComponent<AreaManager>();
        InitGame();
    }
    void InitGame()
    {
        areaM.SetupScene();
    }
}
