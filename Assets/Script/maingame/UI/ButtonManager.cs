using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonmg;

    private Vector3 startpos;

    private Vector3 endpos;

    private string moveflag = "";

    private bool pointerexits = false;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        startpos = new Vector3(buttonmg.transform.position.x, buttonmg.transform.position.y, buttonmg.transform.position.z);
        endpos = new Vector3(buttonmg.transform.position.x, buttonmg.transform.position.y + 4f, buttonmg.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveflag == "close")
        {
            buttonmg.transform.position = Vector3.SmoothDamp(buttonmg.transform.position, endpos, ref velocity, 0.1f);
        }

        if (moveflag == "open")
        {
            buttonmg.transform.position = Vector3.SmoothDamp(buttonmg.transform.position, startpos, ref velocity, 0.1f);
        }

        if (pointerexits == true && Input.GetMouseButton(0) == true)
        {
            moveflag = "close";
        }
        else
        {
            moveflag = "open";
        }
    }

    public void Exit()
    {
        pointerexits = false;
        Debug.Log("Exit");
    }

    public void Enter()
    {
        pointerexits = true;
        Debug.Log("Enter");
    }
}
