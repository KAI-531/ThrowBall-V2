using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    VarCtrl varmg;

    [System.Serializable]
    public class StageClass
    {
        public List<float> tagetdistance;
    }

    [SerializeField]
    private StageClass stagedata;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        varmg.list_tagetdistance = new List<float>(stagedata.tagetdistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
