using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [System.Serializable]
    public class GoalData
    {
        public GameObject goal;
        public GameObject ball;
    }

    [SerializeField]
    private GoalData[] goalball;

    public GoalData[] list_goalball
    {
        get { return goalball; }
    }


    [SerializeField]
    private GameObject idui;

    string[] goalname = { "A", "B", "C", "D" };

    VarCtrl varmg;

    private bool isclone = false;

    private GameObject cloneobj;

    private TextMeshProUGUI IDText;

    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        varmg = GameObject.Find("VarManager").GetComponent<VarCtrl>();
        varmg.int_goaltaget = goalball.Length;
    }

    // Update is called once per frame
    void Update()
    {
        CloneNameUI();

        if (varmg.int_goaltaget <= varmg.int_goalcount && varmg.int_goaltaget != 0 && isGoal == false) // GameClear
        {
            if (varmg.int_maxlevel == varmg.int_level)
            {
                varmg.str_gamemode = "levelcomp";
            }
            else
            {
                varmg.str_gamemode = "result";
            }
            isGoal = true;
        }

        if (varmg.bool_gamemove == false && varmg.int_goalcount != 0)
        {
            varmg.int_goalcount = 0;
        }
    }

    private void CloneNameUI()
    {
        if (varmg.bool_gamemove == false && isclone == false)
        {
            for (int i = 0; i < goalball.Length; i++)
            {
                cloneobj = Instantiate(idui, goalball[i].ball.transform.position, Quaternion.identity, this.transform);
                cloneobj.transform.position = new Vector3(cloneobj.transform.position.x + 0.4f, cloneobj.transform.position.y + 0.4f, 0);

                IDText = cloneobj.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                IDText.text = goalname[i];

                cloneobj = Instantiate(idui, goalball[i].goal.transform.position, Quaternion.identity, this.transform);
                cloneobj.transform.position = new Vector3(cloneobj.transform.position.x + 0.4f, cloneobj.transform.position.y + 0.8f, 0);

                IDText = cloneobj.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                IDText.text = goalname[i];
            }
            isclone = true;
        }
        else if (varmg.bool_gamemove == true)
        {
            foreach (Transform child in gameObject.transform)
            {
                //çÌèúÇ∑ÇÈ
                Destroy(child.gameObject);
            }
            isclone = false;
        }
    }
}
