using UnityEngine;
using System;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    //ボタンプレハブ
    [SerializeField] private GameObject missionButton;

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject image;
    [SerializeField] private Button previous;
    [SerializeField] private Button next;
    [SerializeField] private Text page;

    [SerializeField] private GameObject missions;
    [SerializeField] private GameObject levels;
    private Data data;

    private byte pageNumber;
    private byte levelNumber;

    private void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<Data>();
    }

    public void ToBase()
    {
        SceneMigration.Migrate(AnimaScene.Base);
    }
    public void ToMission()
    {
        SceneMigration.Migrate(AnimaScene.Mission);
    }

    public void LevelSelect(string l)
    {
        switch (l)
        {
            case "1": levelNumber = 0; break;
            case "2": levelNumber = 1; break;
            case "3": levelNumber = 2; break;
            case "4": levelNumber = 3; break;
            default: break;
        }
        Page("s");
        missions.transform.position += Vector3.right * 640f;
        levels.transform.position += Vector3.left * 640f;
    }

    public void ContentGenerator()
    {
        foreach(Transform mission in content.transform)
        {
            Destroy(mission.gameObject);
        }

        for(int i = pageNumber * 5; i < (pageNumber + 1) * 5; i++)
        {
            GameObject Mission = Instantiate(missionButton) as GameObject;
            Mission.transform.SetParent(content.transform);
            Mission.GetComponent<MissionContent>().mission = data.levels[levelNumber].missions[i];
        }
    }

    public void ContentDisplay()
    {
        image.SetActive(true);
        Mission mission = data.selectedMission;
        image.GetComponentInChildren<Text>().text
            = "内容：" + mission.Content + Environment.NewLine
            + "報酬：" + mission.Compensation + "$" + Environment.NewLine;
    }

    public void Page(string p)
    {
        switch (p)
        {
            case "s":
                pageNumber = 0;
                break;
            case "p":
                pageNumber++;
                break;
            case "n":
                pageNumber--;
                break;
            default:break;
        }
        ContentGenerator();
        previous.interactable = pageNumber != 0;
        next.interactable = pageNumber != 2;
        page.text = (pageNumber + 1) + " / 3";
    }
}

