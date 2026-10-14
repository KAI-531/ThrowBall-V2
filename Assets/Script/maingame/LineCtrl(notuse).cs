using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrlold : MonoBehaviour
{
    Rigidbody2D rb2d;

    LineRenderer lineRenderer;

    VarCtrl varmg;

    private float linelength = 0f;

    private bool firstflag = true;

    public List<Vector3> linepos = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();

        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        Vector3 centerpos = GetCenterPosition(this.gameObject.transform);
        rb2d.centerOfMass = new Vector2 (1.0f, 1.0f);
        Debug.Log(rb2d.centerOfMass);
        Debug.Log(new Vector2(centerpos.x, centerpos.y));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (varmg.bool_gamemove == true)
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.isKinematic = false;
        }
        else
        {
            rb2d.isKinematic = true;
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (Input.GetMouseButtonUp(0) && firstflag == true)
        {
            linelength = linedistance();
            if (linelength < 0.2)
            {
               Destroy(this.gameObject);
            }

            firstflag = false;
        }
        */
    }

    private float linedistance()
    {
        for (int i = 0; i < linepos.Count - 1; i++)
        {
            linelength += Vector3.Distance(linepos[i], linepos[i + 1]);
        }
        return linelength;
    }

    public static Vector3 GetCenterPosition(Transform target)
    {
        //非アクティブも含めて、targetとtargetの子全てのレンダラーとコライダーを取得
        var cols = target.GetComponentsInChildren<Collider>(true);
        var rens = target.GetComponentsInChildren<Renderer>(true);

        //コライダーとレンダラーが１つもなければ、target.positionがcenterになる
        if (cols.Length == 0 && rens.Length == 0)
            return target.position;

        bool isInit = false;

        Vector3 minPos = Vector3.zero;
        Vector3 maxPos = Vector3.zero;

        for (int i = 0; i < cols.Length; i++)
        {
            var bounds = cols[i].bounds;
            var center = bounds.center;
            var size = bounds.size / 2;

            //最初の１度だけ通って、minPosとmaxPosを初期化する
            if (!isInit)
            {
                minPos.x = center.x - size.x;
                minPos.y = center.y - size.y;
                minPos.z = center.z - size.z;
                maxPos.x = center.x + size.x;
                maxPos.y = center.y + size.y;
                maxPos.z = center.z + size.z;

                isInit = true;
                continue;
            }

            if (minPos.x > center.x - size.x) minPos.x = center.x - size.x;
            if (minPos.y > center.y - size.y) minPos.y = center.y - size.y;
            if (minPos.z > center.z - size.z) minPos.z = center.z - size.z;
            if (maxPos.x < center.x + size.x) maxPos.x = center.x + size.x;
            if (maxPos.y < center.y + size.y) maxPos.y = center.y + size.y;
            if (maxPos.z < center.z + size.z) maxPos.z = center.z + size.z;
        }
        for (int i = 0; i < rens.Length; i++)
        {
            var bounds = rens[i].bounds;
            var center = bounds.center;
            var size = bounds.size / 2;

            //コライダーが１つもなければ１度だけ通って、minPosとmaxPosを初期化する
            if (!isInit)
            {
                minPos.x = center.x - size.x;
                minPos.y = center.y - size.y;
                minPos.z = center.z - size.z;
                maxPos.x = center.x + size.x;
                maxPos.y = center.y + size.y;
                maxPos.z = center.z + size.z;

                isInit = true;
                continue;
            }

            if (minPos.x > center.x - size.x) minPos.x = center.x - size.x;
            if (minPos.y > center.y - size.y) minPos.y = center.y - size.y;
            if (minPos.z > center.z - size.z) minPos.z = center.z - size.z;
            if (maxPos.x < center.x + size.x) maxPos.x = center.x + size.x;
            if (maxPos.y < center.y + size.y) maxPos.y = center.y + size.y;
            if (maxPos.z < center.z + size.z) maxPos.z = center.z + size.z;
        }

        return (minPos + maxPos) / 2;
    }
}
