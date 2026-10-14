using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class StartCtrl : MonoBehaviour
{
    VarCtrl varmg;

    Image image;

    [SerializeField]
    private Sprite startimg;
    [SerializeField]
    private Sprite stopimg;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        image = GetComponent<Image>();
        image.sprite = startimg;
    }

    // Update is called once per frame
    void Update()
    {
        if (varmg.bool_gamemove == true)
        {
            image.sprite = stopimg;
        }
        else
        {
            image.sprite = startimg;
        }
    }

    public void OnClick()
    {
        if (varmg.bool_gamemove == true)
        {
            varmg.bool_gamemove = false;
        }
        else
        {
            varmg.bool_gamemove = true;
        }
    }
}
