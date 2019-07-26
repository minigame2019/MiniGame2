using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(GameController.Instance.StopAllTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
