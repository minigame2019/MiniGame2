using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public int row;
    public int col;
    public GameObject area;

    public int leftCol;
    public int rightCol;
    // Start is called before the first frame update
    public void SetupScene()
    {
        BoardSetup();
    }

    /// <summary>
    /// 初始化地图
    /// </summary>
    void BoardSetup()
    {
        string colF;
        string rowF;
        leftCol = -col / 2;
        rightCol = col / 2;
        for (int i = -col / 2; i <= col / 2; i++)
        {
            colF = "Col " + i.ToString();
            Transform colFolder = new GameObject(colF).transform;
            colFolder.SetParent(this.transform);
            for (int j = -row / 2; j <= row / 2; j++)
            {
                rowF = "Row " + j.ToString();
                Transform rowFolder = new GameObject(rowF).transform;
                rowFolder.SetParent(colFolder);
                GameObject newArea = Instantiate(area, new Vector3(44.07713f * i, 44.07713f * j, 90f), Quaternion.identity, rowFolder);
                newArea.name = "area";
            }
        }
    }


    /// <summary>
    /// 删除最左列地块，右侧增加一列
    /// </summary>
    public void BoardRefresh()
    {
        string colF_del = "Col " + leftCol.ToString();
        Destroy(this.transform.Find(colF_del).gameObject);

        string colF = "Col " + (rightCol+1).ToString();
        string rowF;
        Transform colFolder = new GameObject(colF).transform;
        colFolder.SetParent(this.transform);
        for (int j = -row / 2; j <= row / 2; j++)
        {
            rowF = "Row " + j.ToString();
            Transform rowFolder = new GameObject(rowF).transform;
            rowFolder.SetParent(colFolder);
            GameObject newArea = Instantiate(area, new Vector3(44.07713f * (rightCol + 1), 44.07713f * j, 90f), Quaternion.identity, rowFolder);
            newArea.name = "area";
        }

        leftCol += 1;
        rightCol += 1;
    }
}
