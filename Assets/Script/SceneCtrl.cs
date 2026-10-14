using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions.Must;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class SceneCtrl : MonoBehaviour
{
    public GameObject fadeobj;

    SpriteRenderer fadeimg;

    // private List<AsyncOperationHandle<GameObject>> scenelist = new List<AsyncOperationHandle<GameObject>>();


    private List<string> scenenames = new List<string>();

    private List<GameObject> sceneobj = new List<GameObject>();

    private AsyncOperationHandle<GameObject> prefabhandle;

    private GameObject prefabobj;

    private GameObject canvas;


    private float fadealpha = 0f;

    private bool fadestate = false; // trueでフェードイン、falseでフェードアウト

    private float fadetime = 0.4f;

    VarCtrl varmg;

    private string gamemodememory; // gamemodeが変更されたかを検出するほう

    DrowCtrl drowCtrl;


    // Start is called before the first frame update
    async void Start()
    {
        fadeimg = fadeobj.GetComponent<SpriteRenderer>();
        fadeimg.color = new Color(0, 0, 0, 0);

        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();

        canvas = GameObject.Find("Canvas");

        drowCtrl = GameObject.Find("DrowCtrl").GetComponent<DrowCtrl>();

        ResetGameVar();

        varmg.str_gamemode = "mainmenu";
        varmg.bool_SceneChange = false;
        LoadScene("title");
        LoadUIScene("title");
        //fadeimg.color += new Color(0, 0, 0, 1);
        //await FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        FadeCtrl();

        SceneContorol();
    }

    private async void SceneContorol()
    {
        if (varmg.bool_SceneChange == true)
        {
            varmg.bool_SceneChange = false;

            Debug.Log("detect " + gamemodememory + "to " + varmg.str_gamemode);

            await FadeOut();
            DestoryAllScene();

            OnSceneDestory(gamemodememory);

            gamemodememory = varmg.str_gamemode;

            switch (varmg.str_gamemode)
            {
                case "mainmenu":
                    Debug.Log("LoadTitle");
                    LoadScene("title");
                    LoadUIScene("title");
                    break;

                case "selectlevel":
                    LoadUIScene("selectlevel");
                    break;

                case "gameplay":
                    LoadLevel(varmg.int_level);
                    break;

                case "result":
                    Debug.Log("LoadResult");

                    Debug.Log(varmg.int_level);
                    Debug.Log(varmg.list_levelscore.Count);
                    if (varmg.int_level > varmg.list_levelscore.Count)
                    {
                        while(varmg.int_level > varmg.list_levelscore.Count)
                        {
                            Debug.Log(varmg.list_levelscore.Count);
                            varmg.list_levelscore.Add(0);
                        }
                    }

                    varmg.list_levelscore[varmg.int_level - 1] = varmg.int_starrate;

                    LoadUIScene("result");
                    break;
                case "levelcomp":
                    LoadUIScene("levelcomp");
                    break;
            }
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            await FadeIn();
        }
    }

    private void OnSceneDestory(string name)
    {
        if (name == "gameplay")
        {
            Debug.Log("Gameplay destory");
            ResetGameVar();
        }
    }

    private void FadeCtrl()
    {
        if (fadestate == true && fadealpha != 1)
        {
            if (fadealpha > 1)
            {
                fadealpha = 1;
            }
            else
            {
                fadealpha += 1f / (float)fadetime * Time.deltaTime;
                fadeimg.color += new Color(0, 0, 0, fadealpha - fadeimg.color.a);
            }
        }

        if (fadestate == false && fadealpha != 0)
        {
            if (fadealpha < 0)
            {
                fadealpha = 0;
            }
            else
            {
                fadealpha -= 1f / (float)fadetime * Time.deltaTime;
                fadeimg.color += new Color(0, 0, 0, fadealpha - fadeimg.color.a);
            }
        }

    }

    public async UniTask FadeOut(float? time = null, Color? color = null) // 暗くなる
    {
        if (color == null)
        {
            color = new Color(0, 0, 0); // デフォルト値
        }

        if (time == null)
        {
            time = fadetime;
        }

        fadealpha = 0f;

        fadestate = true;

        Color setcolor = (Color)color;

        fadeimg.color = new Color(setcolor.r / 255, setcolor.g / 255 , setcolor.b / 255, fadealpha);

        await UniTask.WaitUntil(() => fadealpha == 1f);
    }

    public async UniTask FadeIn(float? time = null, Color? color = null) // 明るくなる
    {
        if (color == null)
        {
            color = new Color(0, 0, 0); // デフォルト値
        }

        if (time == null)
        {
            time = fadetime;
        }

        fadealpha = 1f;

        fadestate = false;

        Color setcolor = (Color)color;

        fadeimg.color = new Color(setcolor.r / 255, setcolor.g / 255, setcolor.b / 255, fadealpha);

        await UniTask.WaitUntil(() => fadealpha == 0f);
    }



    public async void LoadScene(string name)
    {
        prefabhandle = Addressables.LoadAssetAsync<GameObject>("Assets/Scene/" + name + ".prefab");
        GameObject prefab = await prefabhandle.Task;

        prefabobj = Instantiate(prefab, this.transform);
        prefabobj.name = name;
        scenenames.Add(name);
        sceneobj.Add(prefabobj);
    }

    public async void LoadUIScene(string name)
    {
        prefabhandle = Addressables.LoadAssetAsync<GameObject>("Assets/UIScene/" + name + ".prefab");
        GameObject prefab = await prefabhandle.Task;

        prefabobj = Instantiate(prefab, canvas.transform);
        prefabobj.name = name;
        scenenames.Add(name);
        sceneobj.Add(prefabobj);
    }

    public void DestroyScene(string name)
    {
        int index = scenenames.IndexOf(name);
        if (index != -1)
        {
            Destroy(sceneobj[index]);
            scenenames.RemoveAt(index);
            sceneobj.RemoveAt(index);
        }
        else
        {
            Debug.LogError("Scene was not found");
        }
    }

    public void DestoryAllScene()
    {
        int index = 0;
        int size = scenenames.Count;
        for (int i = 0; i < size; i++)
        {
            Destroy(sceneobj[index]);
            scenenames.RemoveAt(index);
            sceneobj.RemoveAt(index);
        }
    }

    public void CloseGame() // Not Working
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


    private void ResetGameVar()
    {
        varmg.int_goaltaget = 0;
        varmg.int_goalcount = 0;
        varmg.bool_gamemove = false;
        varmg.str_drowmode = "pen";
        // varmg.list_ballhistory = new List<Vector3>();
        drowCtrl.RemoveAllLine();
    }

    public void LoadLevel(int level)
    {
        Debug.Log("LoadLevel " + level.ToString());
        ResetGameVar();
        LoadScene("gamelayout");
        LoadScene("level" + level.ToString());
        LoadUIScene("gameplay");
    }
}
