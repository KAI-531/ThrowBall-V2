using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarCtrl : MonoBehaviour
{
    private string gamemode;
    public string str_gamemode
    {
        get { return gamemode; }
        set
        {
            switch (value)
            {
                case "mainmenu":
                case "selectlevel":
                case "gameplay":
                case "result":
                case "levelcomp":
                    gamemode = value;
                    bool_SceneChange = true;
                    break;
                default:
                    Debug.LogWarning("str_gamemode invalid string: " + value);
                    break;
            }
        }
    }

    private bool SceneChange;
    public bool bool_SceneChange
    {
        set { SceneChange = value; }
        get { return SceneChange; }
    }

    private bool gamemove;
    public bool bool_gamemove
    {
        get { return gamemove; }
        set { gamemove = value; }
    }

    private string drowmode;
    public string str_drowmode
    {
        get { return drowmode; }
        set
        {
            switch (value)
            {
                case "pen":
                case "eraser":
                case "result":
                    drowmode = value;
                    break;
                default:
                    Debug.LogWarning("str_drowmode invalid string: " + value);
                    break;
            }
        }
    }

    private int level = -1;
    public int int_level
    {
        get { return level; }
        set { level = value; }
    }

    private int goalcount;
    public int int_goalcount
    {
        get { return goalcount; }
        set { goalcount = value; }
    }

    private int goaltaget;
    public int int_goaltaget
    {
        get { return goaltaget; }
        set { goaltaget = value; }
    }

    private List<float> tagetdistance;
    public List<float> list_tagetdistance
    {
        get { return tagetdistance; }
        set { tagetdistance = value; }
    }

    private float nowdistance;
    public float float_nowdistance
    {
        get { return nowdistance; }
        set { nowdistance = value; }
    }

    private List<Vector3> ballhistory = new List<Vector3>();
    public List<Vector3> list_ballhistory
    {
        get { return ballhistory; }
        set { ballhistory = value; }
    }

    private int starrate;
    public int int_starrate
    {
        get { return starrate; }
        set
        {
            if (value >= 0 && value <= 3)
            {
                starrate = value;
            }
            else
            {
                Debug.LogError("starrate is out of range");
            }
        }
    }

    private int maxlevel = 11;
    public int int_maxlevel
    {
        get { return maxlevel; }
    }

    private List<int> levelscore;
    public List<int> list_levelscore
    {
        get { return levelscore; }
        set { levelscore = value; }
    }


    private string getclass<T>(T  value, int before = 2)
    {
        System.Diagnostics.StackFrame caller = new System.Diagnostics.StackFrame(before);

        //メソッド名
        string methodname = caller.GetMethod().Name;
        //クラス名
        string classname = caller.GetMethod().ReflectedType.Name;
        return "method:"+ methodname + " class:" + classname + " value:" + value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
