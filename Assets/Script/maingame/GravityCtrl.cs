using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GravityCtrl : MonoBehaviour
{
    [SerializeField]
    private float direction;

    [SerializeField]
    private GameObject allow;

    private float gravity = 9.8f;

    private Vector2 gravity_2d;

    public Vector2 vector2_gravity_2d
    {
        get { return gravity_2d; }
        set { gravity_2d = value; }
    }

    // Start is called before the first frame update
    void Start()
    {        
        gravity_2d = new Vector2((float)Math.Sin(direction * (Mathf.PI / 180)) * gravity, (float)Math.Cos(direction * (Mathf.PI / 180)) * gravity);

        //if (this.gameObject.tag == "Goal")
        //{
        //    ObjectCtrl objectCtrl = this.transform.parent.gameObject.GetComponent<ObjectCtrl>();
        //    objectCtrl.Vector2_Gravity = gravity_2d;
        //    objectCtrl.bool_isOnlyGravity = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        double direction = Math.Atan(gravity_2d.y / gravity_2d.x) * 180 / Math.PI - 90;
        if (gravity_2d.x < 0)
        {
            direction = direction * -1;
        }
        allow.transform.eulerAngles = new Vector3(0, 0, (float)direction);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectCtrl objectCtrl;

        if (collision.tag == "Line" || collision.tag == "Goal")
        {
            objectCtrl = collision.transform.parent.gameObject.GetComponent<ObjectCtrl>();
        }
        else
        {
            objectCtrl = collision.gameObject.GetComponent<ObjectCtrl>();
        }
        Debug.Log(collision.gameObject.name);

        objectCtrl.Vector2_Gravity = gravity_2d;
        objectCtrl.bool_isOnlyGravity = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ObjectCtrl objectCtrl;

        if (collision.tag == "Line" || collision.tag == "Goal")
        {
            objectCtrl = collision.transform.parent.gameObject.GetComponent<ObjectCtrl>();
        }
        else
        {
            objectCtrl = collision.gameObject.GetComponent<ObjectCtrl>();
        }

        objectCtrl.bool_isOnlyGravity = false;
    }
}
