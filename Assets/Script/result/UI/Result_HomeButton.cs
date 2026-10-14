using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_HomeButton : MonoBehaviour
{
    VarCtrl varmg;
    SECtrl sectrl;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        sectrl = GameObject.Find("SECtrl").GetComponent<SECtrl>();
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
            varmg.str_gamemode = "mainmenu";
            sectrl.Play("ok");
        }
    }
}
