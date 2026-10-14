using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EraserObjCtrl : MonoBehaviour
{
    VarCtrl varmg;

    SpriteRenderer spriteRender;

    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        spriteRender = GetComponent<SpriteRenderer>();

        collider = GetComponent<CircleCollider2D>();

        spriteRender.enabled = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (varmg.str_drowmode == "eraser" && varmg.bool_gamemove == false && Input.GetMouseButton(0) == true)
        {
            spriteRender.enabled = true;
            this.transform.position = new Vector3(mousepos.x, mousepos.y, 0f);
            collider.enabled = true;
        }
        else
        {
            spriteRender.enabled = false;
            collider.enabled = false;
        }
    }
}
