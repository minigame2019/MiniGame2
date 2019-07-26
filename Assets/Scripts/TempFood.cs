using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(delegate () { GameController.Instance.CreateAllTask("food"); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
