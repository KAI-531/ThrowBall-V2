using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel_LevelButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject selectlv;

    VarCtrl varmg;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        for (int i = 1; i <= varmg.int_maxlevel; i++)
        {
            GameObject cloneobj = Instantiate(selectlv, this.transform);
            cloneobj.GetComponent<SelectLevel_LevelButton>().level = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
