using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class LoadDataManager : MonoBehaviour
{
    VarCtrl varmg;

    void Awake()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
    }

    public void SetVarManager(SaveData data)
    {
        Debug.Log("SetVar");
        //Debug.Log(data.int_maxlevel);
        //varmg.int_maxlevel = data.int_maxlevel;
        varmg.list_levelscore = data.list_levelscore;
    }

    public SaveData SaveVarManager(SaveData data)
    {
        //Debug.Log(data.int_maxlevel);
        // Debug.Log(data.list_levelscore);
        //data.int_maxlevel = varmg.int_maxlevel;
        data.list_levelscore = varmg.list_levelscore;

        return data;
    }
}