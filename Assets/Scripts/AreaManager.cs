using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public int row;
    public int col;
    public GameObject area;

    // Start is called before the first frame update
    public void SetupScene()
    {
        BoardSetup();
    }

    void BoardSetup()
    {
        string colF;
        string rowF;
        for (int i = -row / 2; i <= row / 2; i++)
        {
            colF = "Col " + i.ToString();
            Transform colFolder = new GameObject(colF).transform;
            colFolder.SetParent(this.transform);
            for (int j = -col / 2; j <= col / 2; j++)
            {
                rowF = "Row " + j.ToString();
                Transform rowFolder = new GameObject(rowF).transform;
                rowFolder.SetParent(colFolder);
                GameObject newArea = Instantiate(area, new Vector3(44.07713f * i, 44.07713f * j, 90f), Quaternion.identity, rowFolder);
                newArea.name = "area";
            }
        }
    }
}
