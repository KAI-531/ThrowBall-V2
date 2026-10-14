using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EraserCtrl : MonoBehaviour
{
    VarCtrl varmg;

    Vector3 velocity = Vector3.zero;
    Vector3 openpos = Vector3.zero;
    Vector3 closepos = Vector3.zero;
    Vector3 backpos = Vector3.zero;

    string moveflag = "";

    Vector3 Round(Vector3 self)
    {
        return new Vector3(Mathf.Round(self.x), Mathf.Round(self.y), Mathf.Round(self.z));
    }

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        openpos = new Vector3(this.transform.position.x, this.transform.position.y - 0.6f, 0);
        closepos = new Vector3(this.transform.position.x, this.transform.position.y + 2f, this.transform.position.z);
        backpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        if (varmg.str_drowmode == "eraser" && varmg.bool_gamemove == false)
        {
            if (Round(transform.position) != Round(openpos) && moveflag != "open")
            {
                moveflag = "";
                transform.position = Vector3.SmoothDamp(transform.position, openpos, ref velocity, 0.1f);
            }
            else
            {
                moveflag = "open";
            }
        }else if (varmg.bool_gamemove == true)
        {
            if (Round(transform.position) != Round(closepos) && moveflag != "close")
            {
                moveflag = "";
                transform.position = Vector3.SmoothDamp(transform.position, closepos, ref velocity, 0.1f);
            }
            else
            {
                moveflag = "close";
            }
        }
        else
        {
            if (Round(transform.position) != Round(backpos) && moveflag != "back")
            {
                moveflag = "";
                transform.position = Vector3.SmoothDamp(transform.position, backpos, ref velocity, 0.1f);
            }
            else
            {
                moveflag = "back";
            }
        }
    }

    public void OnClick()
    {
        varmg.str_drowmode = "eraser";
    }
}
