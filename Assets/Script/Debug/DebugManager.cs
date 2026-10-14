using Unity.Burst.Intrinsics;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    //スクロールビュー内のコンテンツの数
    //========================
    const int Index = 5;
    //========================

    //Rectサイズの規格
    const int Margin = 50;
    const int Width = 500;
    const int Height = 100;
    //コンテンツの規格サイズ
    Rect contentRectSize = new Rect(Margin, Height, Width, Height);
    //コンテンツを並べる用の配列
    Rect[] contentRects = new Rect[Index];

    //スクロールの位置更新用
    Vector2 scrollPosition = Vector2.zero;
    //スクロールビューの表示範囲
    Rect position = new Rect(Margin, Height * 2, Width + Margin, Height * 5);
    //スクロールビュー全体の範囲 
    Rect viewRect = new Rect(Margin, Height, Width, Height * Index);

    //スクロールビューの表示切り替え用
    bool show;

    VarCtrl varmg;

    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        //コンテンツのサイズを代入、位置Yを更新して並べる
        for (int i = 0; i < Index; i++)
        {
            contentRects[i] = contentRectSize;
            contentRects[i].y *= i + 1;
        }
    }

    void Update()
    {
        if (Input.GetKey("l"))
        {
            Debug.Log(varmg.float_nowdistance);
        }
    }

    private void OnGUI()
    {
        //ボタンとボックスがGUIStyleになるように設定
        GUIStyle stylebutton = GUI.skin.GetStyle("button");
        GUIStyle stylebox = GUI.skin.GetStyle("box");
        //ボタンとボックスの fontSize変更
        stylebutton.fontSize = 40;
        stylebox.fontSize = 40;
        int idx = -1;

        //スクロールビュー表示切り替えボタン
        if (GUI.Button(new Rect(Margin, Margin, Width, Height), "Debug"))
        {
            show = !show;
        }

        if (!show) return;

        //スクロールビューの開始位置
        scrollPosition = GUI.BeginScrollView(position, scrollPosition, viewRect);

        //タイムスケールの表示
        GUI.Box(contentRects[++idx], $"Level: {varmg.int_level}");

        //再生 加速　ボタン
        if (GUI.Button(contentRects[++idx], ">"))
        {
            varmg.int_level += 1;
        }
        //再生 減速　ボタン
        if (GUI.Button(contentRects[++idx], "<"))
        {
            varmg.int_level -= 1;
        }

        //以降は上記要領でデバッグ機能を追加 ====================
        GUI.Box(contentRects[++idx], "Call Event");

        if (GUI.Button(contentRects[++idx], "Load Level"))
        {
            varmg.str_gamemode = "gameplay";
        }

        // スクロールビューの終了位置
        GUI.EndScrollView();
    }
}