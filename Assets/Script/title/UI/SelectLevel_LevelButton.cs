using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel_LevelButton : MonoBehaviour
{
    public int level;

    VarCtrl varmg;
    SECtrl sectrl;

    [SerializeField]
    private GameObject levelText;

    [SerializeField]
    private GameObject levelImgObj;

    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        sectrl = GameObject.Find("SECtrl").GetComponent<SECtrl>();

        levelText.GetComponent<TextMeshProUGUI>().text = "Lv " + level.ToString();
        img = levelImgObj.GetComponent<Image>();
        if (varmg.list_levelscore.Count + 1 < level)
        {
            float dark = 140f / 255f;
            img.color = new Color(dark, dark, dark, 1);

            levelImgObj.GetComponent<Button>().interactable = false;
        }
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
            isClick = true;
            varmg.int_level = level;
            varmg.str_gamemode = "gameplay";
            sectrl.Play("ok");
        }
    }
}
