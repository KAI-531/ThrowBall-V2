using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_RestartButton : MonoBehaviour
{
    VarCtrl varmg;
    SECtrl sectrl;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        sectrl = GameObject.Find("SECtrl").GetComponent<SECtrl>();
        varmg.int_level += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isClick = false;
    public void OnClick()
    {
        if (isClick == false)
        {
            isClick = true;
            varmg.int_level -= 1;
            varmg.str_gamemode = "gameplay";
            sectrl.Play("ok");
            Debug.Log(varmg.str_gamemode);
        }
    }
}
