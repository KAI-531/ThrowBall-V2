using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class DistanceVarCtrl : MonoBehaviour
{
    VarCtrl varmg;

    Slider slider;

    [SerializeField]
    private GameObject splitbar;

    private float width;

    private float splitwidth;

    //private List<Image> spritbar = new List<Image>();

    //[SerializeField]
    //private Image fillobj;

    //[SerializeField]
    //private Image backobj;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        slider = GetComponent<Slider>();

        width = GetComponent<RectTransform>().rect.width;
        splitwidth = splitbar.GetComponent<RectTransform>().rect.width;

        float distancecount = 0;
        float tagetdistancesum = varmg.list_tagetdistance.Sum();
        for (int i = 0; i + 1 < varmg.list_tagetdistance.Count; i++)
        {
            distancecount += varmg.list_tagetdistance[i];

            float x = (distancecount / tagetdistancesum * width) - ((width - splitwidth) / 2);
            GameObject cloneobj = Instantiate(splitbar, this.transform);
            cloneobj.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, 0, 0);
            //spritbar.Add(cloneobj.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = varmg.float_nowdistance / varmg.list_tagetdistance.Sum();
    }

    //public void Enter()
    //{
    //    //int end = 100;
    //    //float second = 1.0f;
    //    //for (int i = 0; i <= 100; i++)
    //    //{
    //    //    for (int j = 0; j < spritbar.Count; j++)
    //    //    {
    //    //        spritbar[j].color = new Color(spritbar[j].color.r, spritbar[j].color.g, spritbar[j].color.b, spritbar[j].color.a - 1);
    //    //    }
    //    //    fillobj.color = new Color(fillobj.color.r, fillobj.color.g, fillobj.color.b, fillobj.color.a - 1);
    //    //    backobj.color = new Color(backobj.color.r, backobj.color.g, backobj.color.b, backobj.color.a - 1);

    //    float color = 50f;
    //    for (int j = 0; j < spritbar.Count; j++)
    //    {
    //        spritbar[j].color = new UnityEngine.Color(spritbar[j].color.r, spritbar[j].color.g, spritbar[j].color.b, color / 255f);
    //    }
    //    fillobj.color = new UnityEngine.Color(fillobj.color.r, fillobj.color.g, fillobj.color.b, color / 255f);
    //    backobj.color = new UnityEngine.Color(backobj.color.r, backobj.color.g, backobj.color.b, color / 255f);
    //}

    //public void Exit()
    //{
    //    //int end = 100;
    //    //float second = 1.0f;
    //    //for (int i = 0; i <= 100; i++)
    //    //{
    //    //    for (int j = 0; j < spritbar.Count; j++)
    //    //    {
    //    //        spritbar[j].color = new Color(spritbar[j].color.r, spritbar[j].color.g, spritbar[j].color.b, spritbar[j].color.a + 1);
    //    //    }
    //    //    fillobj.color = new Color(fillobj.color.r, fillobj.color.g, fillobj.color.b, fillobj.color.a + 1);
    //    //    backobj.color = new Color(backobj.color.r, backobj.color.g, backobj.color.b, backobj.color.a + 1);
    //    //}

    //    for (int j = 0; j < spritbar.Count; j++)
    //    {
    //        spritbar[j].color = new UnityEngine.Color(spritbar[j].color.r, spritbar[j].color.g, spritbar[j].color.b, 1.0f);
    //    }
    //    fillobj.color = new UnityEngine.Color(fillobj.color.r, fillobj.color.g, fillobj.color.b, 1.0f);
    //    backobj.color = new UnityEngine.Color(backobj.color.r, backobj.color.g, backobj.color.b, 1.0f);
    //}
}
