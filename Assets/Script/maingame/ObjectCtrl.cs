using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ObjectCtrl : MonoBehaviour
{
    VarCtrl varmg;

    private Rigidbody2D rb2d;

    private Vector3 startpos;
    private Vector3 euler;

    //[SerializeField]
    //private bool isGravity = false;

    [SerializeField]
    private bool isGravity_interference = true; // TrueÇ≈èdóÕÇÃä±è¬ÇéÛÇØÇÈ

    [SerializeField]
    private float gravity_direction = 0;

    [SerializeField]
    private bool gravity_move = true;

    [SerializeField]
    private bool showallow = true;

    private float gravity = 9.8f;

    Vector2 my_gravity;

    [SerializeField]
    private GameObject allow;


    private bool isOnlyGravity = false;
    public bool bool_isOnlyGravity
    {
        get { return isOnlyGravity; }
        set { isOnlyGravity = value; }
    }

    private Vector2 Gravity = Vector2.zero;
    public Vector2 Vector2_Gravity
    {
        get { return Gravity; }
        set { Gravity = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        rb2d = GetComponent<Rigidbody2D>();

        startpos = this.transform.position;
        euler = this.transform.localEulerAngles;

        my_gravity = new Vector2((float)Math.Sin(gravity_direction * (Mathf.PI / 180)) * gravity, (float)Math.Cos(gravity_direction * (Mathf.PI / 180)) * gravity);

        rb2d.gravityScale = 0;
        
        if (isGravity_interference == false)
        {
            allow.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (showallow == false && allow != null)
        {
            allow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (varmg.bool_gamemove == true && gravity_move == true)
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.isKinematic = false;
            if (showallow == true)
            {
                allow.SetActive(false);
            }
        }
        else
        {
            rb2d.isKinematic = true;
            this.transform.position = startpos;
            // this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.localEulerAngles = euler;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            if (showallow == true)
            {
                allow.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        if (isGravity_interference == true)
        {
            if (isOnlyGravity)
            {
                // rb2d.gravityScale = 0;
                rb2d.AddForce(Gravity, ForceMode2D.Force);

                if (showallow == true)
                {
                    double direction = Math.Atan(Gravity.y / Gravity.x) * 180 / Math.PI - 90;
                    if (Gravity.x < 0)
                    {
                        direction = direction * -1;
                    }
                    allow.transform.eulerAngles = new Vector3(0, 0, (float)direction);
                }
            }
            else
            {
                // rb2d.gravityScale = 1;
                rb2d.AddForce(my_gravity, ForceMode2D.Force);

                if (showallow == true)
                {
                    double direction = Math.Atan(my_gravity.y / my_gravity.x) * 180 / Math.PI - 90;
                    if (my_gravity.x < 0)
                    {
                        direction = direction * -1;
                    }
                    allow.transform.eulerAngles = new Vector3(0, 0, (float)direction);
                }
            }
        }else
        {
            rb2d.AddForce(my_gravity, ForceMode2D.Force);

            if (showallow == true)
            {
                double direction = Math.Atan(my_gravity.y / my_gravity.x) * 180 / Math.PI - 90;
                if (my_gravity.x < 0)
                {
                    direction = direction * -1;
                }
                allow.transform.eulerAngles = new Vector3(0, 0, (float)direction);
            }
        }
    }

    //private void OnCollisionEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.tag);
    //    if (collision.tag != "GravityChanger")
    //    {
    //        GravityCtrl gravity_ctrl;

    //        gravity_ctrl = collision.gameObject.GetComponent<GravityCtrl>();
            
    //        Vector2_Gravity = gravity_ctrl.vector2_gravity_2d;
    //        bool_isOnlyGravity = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "GravityChanger")
    //    {
    //        bool_isOnlyGravity = false;
    //    }
    //}
}
