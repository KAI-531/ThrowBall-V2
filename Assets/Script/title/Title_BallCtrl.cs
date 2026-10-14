using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Title_BallCtrl : MonoBehaviour
{

    Rigidbody2D rb2d;
    VarCtrl varmg;

    Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        varmg.bool_gamemove = true;

        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -6)
        {
            this.transform.position = startpos;
            rb2d.linearVelocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
            Debug.Log(rb2d.linearVelocity);
        }
    }
}
