using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveControllor : MonoBehaviour
{
    public int carPosX = 0;
    public int carPosY = 0;
    public Text carPosText;

    public int targetPosX = 0;
    public int targetPosY = 0;
    public Vector3 targetP;

    private Vector3 currentVelocity = Vector3.zero;
    private GameObject areas;
    private GameObject curAreaStatus;
    private GameObject tarAreaStatus;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        areas = GameObject.Find("/Canvas/Map/AreaLayout");
        targetP = transform.position;
        //curAreaStatus = areas.transform.Find(PosPath(carPosX, carPosY)).gameObject;
    }

    string PosPath(int x,int y)
    {
        return "Col " + x.ToString() + "/Row " + y.ToString()+ "/area/areaStatus";
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKey(KeyCode.W))
        {
            if (carPosY < areas.GetComponent<AreaManager>().col/2 && !isMoving)
            {
                tarAreaStatus = areas.transform.Find(PosPath(carPosX, carPosY+1)).gameObject;
                if (tarAreaStatus.GetComponent<AreaStatus>().status != -1)
                {
                    targetPosX = carPosX;
                    targetPosY = carPosY + 1;
                    targetP.Set(44.07713f * targetPosX, 44.07713f * targetPosY, 90f);
                    isMoving = true;
                }
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (carPosY > -areas.GetComponent<AreaManager>().col / 2 && !isMoving)
            {
                tarAreaStatus = areas.transform.Find(PosPath(carPosX, carPosY - 1)).gameObject;
                if (tarAreaStatus.GetComponent<AreaStatus>().status != -1)
                {
                    targetPosX = carPosX;
                    targetPosY = carPosY - 1;
                    targetP.Set(44.07713f * targetPosX, 44.07713f * targetPosY, 90f);
                    isMoving = true;
                }
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (carPosX > -areas.GetComponent<AreaManager>().row / 2 && !isMoving)
            {
                tarAreaStatus = areas.transform.Find(PosPath(carPosX-1, carPosY)).gameObject;
                if (tarAreaStatus.GetComponent<AreaStatus>().status != -1)
                {
                    targetPosX = carPosX-1;
                    targetPosY = carPosY;
                    targetP.Set(44.07713f * targetPosX, 44.07713f * targetPosY, 90f);
                    isMoving = true;
                }
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (carPosX < areas.GetComponent<AreaManager>().row / 2 && !isMoving)
            {
                tarAreaStatus = areas.transform.Find(PosPath(carPosX+1, carPosY)).gameObject;
                if (tarAreaStatus.GetComponent<AreaStatus>().status != -1)
                {
                    targetPosX = carPosX+1;
                    targetPosY = carPosY;
                    targetP.Set(44.07713f * targetPosX, 44.07713f * targetPosY, 90f);
                    isMoving = true;
                }
            }
        }

        float deltaX = transform.position.x - targetP.x;
        float deltaY = transform.position.y - targetP.y;
        
        if(deltaX<1f && deltaX>-1f && deltaY<1f && deltaY>-1f)
        {
            carPosX = targetPosX;
            carPosY = targetPosY;
            isMoving = false;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetP, ref currentVelocity, 0.1f);
    }
}
