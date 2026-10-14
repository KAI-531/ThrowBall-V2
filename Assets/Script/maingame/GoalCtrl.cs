using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class GoalCtrl : MonoBehaviour
{
    // [SerializeField]
    // private GameObject goalManager;

    private GoalManager gm;

    VarCtrl varmg;

    SECtrl sectrl;

    private Animator animator;

    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        sectrl = GameObject.Find("SECtrl").GetComponent<SECtrl>();
        gm = this.transform.parent.parent.Find("GoalManager").GetComponent<GoalManager>();

        animator = this.transform.parent.Find("FlagCenter").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (varmg.bool_gamemove == false)
        {
            animator.SetBool("Flag Anim", false);
            isGoal = false;
        }
    }

    async void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("toutch" + collision.name);
        int goalindex = -1;

        for (int i = 0; i < gm.list_goalball.Length; i++)
        {
            if (gm.list_goalball[i].goal == this.transform.parent.gameObject)
            {
                goalindex = i;
                break;
            }
        }

        if (collision == gm.list_goalball[goalindex].ball.GetComponent<Collider2D>() && isGoal == false)
        {
            sectrl.Play("goal");
            animator.SetBool("Flag Anim", true);
            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
            varmg.int_goalcount ++;
            isGoal = true;
        }
        else if (goalindex == -1)
        {
            Debug.LogWarning("GoalObject Not Setting");
        }
    }
}
