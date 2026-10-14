using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_BallManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private Vector3 clonepos = new Vector3(-7.65f, 5.6f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        CreateBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int count = 0;
    void CreateBall()
    {
        GameObject obj = Instantiate(ball, this.transform);
        obj.transform.position = new Vector3(-7.65f, 5.6f, 0f);
        count ++;
        if (count < 3)
        {
            Invoke(nameof(CreateBall), 9f);
        }
    }
}
