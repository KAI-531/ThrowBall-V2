using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class test : MonoBehaviour
{
    private const float RAY_DISPLAY_TIME = 1;

    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.rotation.z;
        Ray2D ray = new Ray2D(transform.position,  transform.right);
        Ray2D ray2 = new Ray2D(transform.position, new Vector3(transform.right.x * -1, transform.right.y * -1, transform.right.z));

        //if (flag)
        //{
            RaycastHit2D test = RaycastAndDraw(ray.origin, ray.direction, transform.localScale.x / 2, 1);
        //    flag = false;
        //}
        //else
        //{
            RaycastHit2D tes = RaycastAndDraw(ray2.origin, ray2.direction, transform.localScale.x / 2, 1);
        //    flag = true;
        //}
        //Debug.Log(flag);
    }

    public static RaycastHit2D RaycastAndDraw(Vector2 origin, Vector2 direction, float maxDistance, int layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, maxDistance, layerMask);

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
        // Debug.Log(hit.collider.gameObject.name);

        return hit;
    }
}
