using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StarCtrl : MonoBehaviour
{
    [SerializeField]
    private Sprite staractive;

    [SerializeField]
    private Sprite starinactive;

    [SerializeField]
    private Vector3 startpos;

    [SerializeField]
    private float size;

    [SerializeField]
    private float distance;

    VarCtrl varmg;

    private List<GameObject> starlist = new List<GameObject>();
    private List<Image> starimglist = new List<Image>(); 


    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        for (int i = 0; i < varmg.list_tagetdistance.Count; i++)
        {
            GameObject cloneobj = new GameObject();
            cloneobj.name = "Star";
            cloneobj.transform.parent = this.transform;
            cloneobj.AddComponent<RectTransform>();
            cloneobj.AddComponent<CanvasRenderer>();
            cloneobj.AddComponent<Image>();

            RectTransform recttransform = cloneobj.GetComponent<RectTransform>();
            recttransform.anchoredPosition = new Vector3(startpos.x + distance * i, startpos.y, startpos.z);
            recttransform.sizeDelta = new Vector2(size, size);
            recttransform.localScale = new Vector3(1, 1, 1);

            starlist.Add(cloneobj);
            starimglist.Add(cloneobj.GetComponent<Image>());

            starimglist[i].sprite = staractive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float count = 0;
        int starcount = starlist.Count;
        int starrate = 0;
        for (int i = 0;i < starcount; i++)
        {
            count += varmg.list_tagetdistance[i];
            
            if (varmg.float_nowdistance < count)
            {
                starimglist[starcount - 1 - i].sprite = staractive;
                starrate ++;
            }
            else
            {
                starimglist[starcount - 1 - i].sprite = starinactive;
            }


            RectTransform recttransform = starlist[i].GetComponent<RectTransform>();
            recttransform.anchoredPosition = new Vector3(startpos.x + distance * i, startpos.y, startpos.z);
            recttransform.sizeDelta = new Vector2(size, size);
            recttransform.localScale = new Vector3(1, 1, 1);
        }
        varmg.int_starrate = starrate;
    }
}
