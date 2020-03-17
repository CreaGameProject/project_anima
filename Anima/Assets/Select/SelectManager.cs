using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Button previous;
    [SerializeField] private Button next;
    [SerializeField] private Text page;
    [SerializeField] private Button back;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject missions;
    [SerializeField] private GameObject important;
    [SerializeField] private GameObject levels;

    private int pageNumber;

    private void Start()
    {
        pageNumber = 1;
        back.onClick.AddListener(() => {
            ToBase();
        });
    }

    public void ToMissionPage(int index)
    {
        levels.SetActive(false);
        missions.SetActive(true);
        ContentDisplay(index);
        Page(-2);
        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(() => ToLevelPage());
    }

    private void ToLevelPage()
    {
        missions.SetActive(false);
        levels.SetActive(true);
        image.SetActive(false);
        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(() => ToBase());
    }

    private void ToBase()
    {
        GameObject.Find("TableCamera").GetComponent<CameraAngle>().Select_to_Base();
    }

    public void ToMission()
    {
        if (Data.Instance.MainWeapon == null)
        {
            Debug.Log("No weapon!");
        }
        else
        {
            SceneMigration.MigrateSingle(AnimaScene.Mission);
        }
    }

    private void ContentDisplay(int index)
    {
        Button[] buttons = missions.GetComponentsInChildren<Button>();
        for(int i = 0; i < Data.Instance.levels[index].missions.Length; i++)
        {
            Mission mission = Data.Instance.levels[index].missions[i];
            buttons[i].gameObject.GetComponentInChildren<Text>().text = mission.name;
            buttons[i].onClick.AddListener(() =>{
                Data.Instance.selectedMission = mission;
                MissionDisplay();
            });
        }
    }

    public void Page(int index)
    {
        pageNumber += index;
        if (pageNumber <= 1)
        {
            pageNumber = 1;
            previous.interactable = false;
        }
        else if (3 <= pageNumber)
        {
            pageNumber = 3;
            next.interactable = false;
        }
        else
        {
            previous.interactable = true;
            next.interactable = true;
        }
        page.text = pageNumber.ToString() + " / 3";
    }

    public void MissionDisplay()
    {
        image.SetActive(true);
        Mission mission = Data.Instance.selectedMission;
        string content="";
        foreach(Prey_Number p in mission.Prey)
        {
            content = content + p.PreyName + p.number.ToString() + "頭 ";
        }
        Text[] texts = image.GetComponentsInChildren<Text>();
        texts[0].text = "内容：" + content + "の狩猟";
        texts[1].text = "報酬：" + mission.Compensation + "$";
        texts[2].text = "時間：" + mission.Limit + "分";
    }
}

