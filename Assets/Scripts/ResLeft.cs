using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FightSystem;

public class ResLeft : MonoSingleton<ResLeft>
{
    public GameObject car;
    
    public int curX;
    public int curY;
    public GameObject curAreaStatus;

    //private int curX0;
    //private int curY0;
    private GameObject areas;
    private float t = 0f;
    private Text textWood;
    private Text textIron;
    private Text textFood;

    private Text textEnemy;
    private Text textEstimated;

    public AreaStatus curAS;

    string PosPath(int x, int y)
    {
        return "Col " + x.ToString() + "/Row " + y.ToString() + "/area/areaStatus";
    }

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("/Canvas/Car");
        areas = GameObject.Find("/Canvas/Map/AreaLayout");
        textWood = this.gameObject.transform.Find("wood/left").GetComponent<Text>();
        textIron = this.gameObject.transform.Find("iron/left").GetComponent<Text>();
        textFood = this.gameObject.transform.Find("food/left").GetComponent<Text>();

        textEnemy = this.gameObject.transform.Find("enemy/info").GetComponent<Text>();
        textEstimated = this.gameObject.transform.Find("enemy/estimated").GetComponent<Text>();

        //curX0 = car.GetComponent<MoveControllor>().carPosX;
        //curY0 = car.GetComponent<MoveControllor>().carPosY;
    }

    // Update is called once per frame
    void Update()
    {
        if(t<0.1f)
        {
            t += Time.deltaTime;
        }
        else
        {
            ChangeNum();
            t = 0f;
        }
    }
    public void ChangeNum()
    {
        curX = car.GetComponent<MoveControllor>().carPosX;
        curY = car.GetComponent<MoveControllor>().carPosY;
        curAreaStatus = areas.transform.Find(PosPath(curX, curY)).gameObject;
        curAS = curAreaStatus.GetComponent<AreaStatus>();

        textWood.text = "余量：" + curAS.numWood.ToString();
        textIron.text = "余量：" + curAS.numIron.ToString();
        textFood.text = "余量：" + curAS.numFood.ToString();

        updateEnemyInfo(curAS);     
    }

    private void updateEnemyInfo(AreaStatus curAS)
    {
        int enemyID = curAS.enemyID;
        if(enemyID < 0)
        {
            textEnemy.text = "无敌人";
            textEstimated.text = "";
            return;
        }

        if (!curAS.enemy_alive)
        {
            textEnemy.text = "敌人已被消灭";
            textEstimated.text = "";
            return;
        }

        Enemy enemy = new EnemyCreator().createByID(enemyID);
        textEnemy.text = enemy.name;

        Player player = GameController.Instance.CurrentPlayer;
        if (player)
        {
            FightResult efr = new Fight(new Fighter(player), enemy).estimatedResult();

            if(efr.result == (int)WinOrLose.Win)
            {
                textEstimated.text = "预计损失血量" + efr.damage;
                return;
            }
            textEstimated.text = "不可战胜";
            
        }
    }
}
