using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            ResLeft.Instance.curAS.fight();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
