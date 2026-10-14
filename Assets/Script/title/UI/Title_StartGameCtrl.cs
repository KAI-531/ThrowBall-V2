using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_StartGameCtrl : MonoBehaviour
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
            if (varmg.int_level == -1)
            {
                varmg.int_level = varmg.list_levelscore.Count;
                if (varmg.int_level == 0)
                {
                    varmg.int_level = 1;
                }
            }
            isClick = true;
            varmg.str_gamemode = "gameplay";
            sectrl.Play("ok");
        }

    }
}
