using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    Rigidbody2D rb2d;

    VarCtrl varmg;

    private bool isDrow = true;

    private float beforedistance = 0;

    public bool isOnBox = false;

    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();

        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(varmg.bool_gamemove == true)
        //{
        //    rb2d.constraints = RigidbodyConstraints2D.None;
        //    rb2d.isKinematic = false;
        //}
        //else
        //{
        //    rb2d.isKinematic = true;
        //    this.gameObject.transform.position = new Vector3(0, 0, 0);
        //    this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //    rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        //}

        if (Input.GetMouseButton(0) == true && isDrow == true)
        {
            varmg.float_nowdistance += DistanceMeasure() - beforedistance;
            beforedistance = DistanceMeasure();
        }
        else if(Input.GetMouseButton(0) == false && isDrow == true)
        {
            isDrow = false;
            if (isOnBox == true || this.transform.childCount == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DeleteLine")
        {
            Destroy(this.gameObject);
        }
    }

    private float DistanceMeasure()
    {
        float distance = 0;
        foreach (Transform child in this.transform)
        {
            distance += child.transform.localScale.x;
        }
        return distance;
    }

    private void OnDestroy()
    {
        varmg.float_nowdistance -= DistanceMeasure();
    }
}
