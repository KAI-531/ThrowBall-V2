using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{

    // private List<Vector3> ballhistory = new List<Vector3>();

    VarCtrl varmg;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject cloneObj;

    private float timecount;

    private float timetaget = 0.5f;

    private bool isClone;

    private List<Vector3> ballhistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (varmg.bool_gamemove == true)
        {
            foreach (Transform child in this.transform)
            {
                if (child.name != "Allow")
                {
                    Destroy(child.gameObject);
                }
            }

            isClone = false;

            timecount += Time.deltaTime;
            if (timecount >= timetaget)
            {
                timecount = timecount - timetaget;
                ballhistory.Add(this.transform.position);
            }
        }
        else if (isClone == false)
        {
            timecount = 0;
            isClone = true;

            for (int i = 0; i < ballhistory.Count; i++)
            {
                GameObject obj = Instantiate(cloneObj, this.transform);
                obj.transform.position = ballhistory[i];
                obj.GetComponent<SpriteRenderer>().color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 130f / 255f);
                Debug.Log(obj.GetComponent<SpriteRenderer>().color);
            }

            ballhistory = new List<Vector3>();
        }
    }
}
