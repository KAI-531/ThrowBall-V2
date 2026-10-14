using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DrawCtrl : MonoBehaviour
{

    [SerializeField] Material lineMaterial;
    [SerializeField] Color lineColor;
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;


    GameObject lineObj;
    LineRenderer lineRenderer;
    Rigidbody2D linerb2d;
    List<Vector2> linePoints;

    VarCtrl varmg;

    // Start is called before the first frame update
    void Start()
    {
        //ListÇÃèâä˙âª
        linePoints = new List<Vector2>();

        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (varmg.str_drowmode == "pen" && varmg.bool_gamemove == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AddLineObject();
            }
            if (Input.GetMouseButton(0))
            {
                AddPosition();
            }
        }
    }

    private void AddLineObject()
    {
        lineObj = new GameObject();
        lineObj.name = "Line";
        lineObj.AddComponent<LineRenderer>();
        lineObj.AddComponent<EdgeCollider2D>();
        lineObj.AddComponent<Rigidbody2D>();
        lineObj.AddComponent<LineCtrl>();
        lineObj.transform.SetParent(transform);
        SetLineRenderer();
    }

    private void SetLineRenderer()
    {
        lineRenderer = lineObj.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.material = lineMaterial;
        lineRenderer.material.color = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.useWorldSpace = false;

        linerb2d = lineObj.GetComponent<Rigidbody2D>();
        linerb2d.isKinematic = true;

        linePoints = new List<Vector2>();
    }

    private void AddPosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);


        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPos);
        linePoints.Add(worldPos);
        // lineObj.GetComponent<LineCtrl>().linepos.Add(worldPos);
        Vector2 test = worldPos;
        lineObj.GetComponent<EdgeCollider2D>().SetPoints(linePoints);
    }
}
