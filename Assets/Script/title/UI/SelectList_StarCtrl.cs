using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectList_StarCtrl : MonoBehaviour
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

    SelectLevel_LevelButton lb;

    private List<GameObject> starlist = new List<GameObject>();
    private List<Image> starimglist = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        lb = this.transform.parent.GetComponent<SelectLevel_LevelButton>();

        for (int i = 0; i < 3; i++)
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
            starimglist[i].raycastTarget = false;
        }


        int starcount = starlist.Count;
        int starrate = 0;
        for (int i = 0; i < starcount; i++)
        {

            if (varmg.list_levelscore.Count >= lb.level)
            {
                if (starcount - i <= varmg.list_levelscore[lb.level - 1])
                {
                    starimglist[starcount - 1 - i].sprite = staractive;
                    starrate++;
                }
                else
                {
                    starimglist[starcount - 1 - i].sprite = starinactive;
                }
            }
            else
            {
                starimglist[starcount - 1 - i].sprite = starinactive;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int starcount = starlist.Count;
        //int starrate = 0;
        //for (int i = 0; i < starcount; i++)
        //{

        //    if (varmg.list_levelscore.Count >= lb.level)
        //    {
        //        if (starcount - i <= varmg.list_levelscore[lb.level - 1])
        //        {
        //            starimglist[starcount - 1 - i].sprite = staractive;
        //            starrate++;
        //        }
        //        else
        //        {
        //            starimglist[starcount - 1 - i].sprite = starinactive;
        //        }
        //    }
        //    else
        //    {
        //        starimglist[starcount - 1 - i].sprite = starinactive;
        //    }


        //    RectTransform recttransform = starlist[i].GetComponent<RectTransform>();
        //    recttransform.anchoredPosition = new Vector3(startpos.x + distance * i, startpos.y, startpos.z);
        //    recttransform.sizeDelta = new Vector2(size, size);
        //    recttransform.localScale = new Vector3(1, 1, 1);
        //}
    }
}
