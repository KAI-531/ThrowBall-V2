using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ShowLevelCtrl : MonoBehaviour
{
    VarCtrl varmg;

    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        
        tmp = GetComponent<TextMeshProUGUI>();

        tmp.text = "Level " + varmg.int_level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
