using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LineCtrl : MonoBehaviour
{
    LineManager lineManager;

    VarCtrl varmg;

    BoxCollider2D bc2d;

    SpriteRenderer spriteRenderer;


    private bool isDrow = true;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            lineManager = this.transform.parent.GetComponent<LineManager>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e.Message);
            Destroy(this.gameObject);
        }
        

        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        bc2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(lineManager.isOnBox == true)
        {
            spriteRenderer.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrow == true)
        {
            bc2d.enabled = false;

            float angle = transform.rotation.z;
            Ray2D rayright = new Ray2D(transform.position, transform.right);
            Ray2D rayleft = new Ray2D(transform.position, new Vector3(transform.right.x * -1, transform.right.y * -1, transform.right.z));

            RaycastHit2D hitright = RaycastAndDraw(rayright.origin, rayright.direction, transform.localScale.x / 2, 1);
            RaycastHit2D hitleft = RaycastAndDraw(rayleft.origin, rayleft.direction, transform.localScale.x / 2, 1);
            if (hitleft.collider != null && hitleft.collider.gameObject.tag == "Wall")
            {
                lineManager.isOnBox = true;
            }
            if (hitright.collider != null && hitright.collider.gameObject.tag == "Wall")
            {
                lineManager.isOnBox = true;
            }
        }

        if (Input.GetMouseButton(0) == false && isDrow == true)
        {
            isDrow = false;
            bc2d.enabled = true;
        }

        if (lineManager.isOnBox == true)
        {
            spriteRenderer.color = Color.red;
        }
    }

    public static RaycastHit2D RaycastAndDraw(Vector2 origin, Vector2 direction, float maxDistance, int layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, maxDistance, layerMask);

        float RAY_DISPLAY_TIME = 1;

        //è’ìÀéûÇÃRayÇâÊñ Ç…ï\é¶
        if (hit.collider)
        {
            Debug.DrawRay(origin, hit.point - origin, Color.blue, RAY_DISPLAY_TIME, false);
        }
        //îÒè’ìÀéûÇÃRayÇâÊñ Ç…ï\é¶
        else
        {
            Debug.DrawRay(origin, direction * maxDistance, Color.green, RAY_DISPLAY_TIME, false);
        }

        return hit;
    }
}
