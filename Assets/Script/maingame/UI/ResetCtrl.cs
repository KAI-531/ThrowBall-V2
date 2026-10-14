using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ResetCtrl : MonoBehaviour
{
    VarCtrl varmg;

    SceneCtrl sceneCtrl;

    DrowCtrl drowCtrl;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        sceneCtrl = this.transform.root.gameObject.GetComponent<SceneCtrl>();

        drowCtrl = GameObject.Find("DrowCtrl").GetComponent<DrowCtrl>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void OnClick()
    {
        animator.SetTrigger("Reset Anim");
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        await sceneCtrl.FadeOut();
        
        drowCtrl.RemoveAllLine();
        // varmg.list_ballhistory = new List<Vector3>();
        varmg.bool_gamemove = false;

        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

        await sceneCtrl.FadeIn();
    }
}
