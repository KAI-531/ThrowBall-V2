using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Rendering;

public class DrowCtrl : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject linemanager;

    private GameObject manager;

    public float lineLength = 0.1f;
    public float lineWidth = 0.1f;

    private Vector3 touchPos;

    VarCtrl varmg;

    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
    }

    void Update()
    {
        if (varmg.str_drowmode == "pen" && varmg.str_gamemode == "gameplay" && varmg.bool_gamemove == false)
        {
            drawLine();
        }
    }

    // https://qiita.com/Nicky/items/348a2b3da591c9c5ff39
    void drawLine()
    {

        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;

            manager = Instantiate(linemanager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            manager.transform.parent = this.transform;
        }

        if (Input.GetMouseButton(0))
        {

            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;

            if ((endPos - startPos).magnitude > lineLength)
            {
                GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

                obj.transform.parent = manager.transform;

                touchPos = endPos;
            }
        }
    }

    public void RemoveAllLine()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
