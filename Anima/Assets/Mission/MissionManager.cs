using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MissionManager : MonoBehaviour
{
    public float damage;
    [SerializeField] private RawImage MainIcon;
    [SerializeField] private RawImage SubIcon;
    [SerializeField] private GameObject clear;

    //制限時間管理(タキサイキアに影響されない)
    private DateTime start;
    private TimeSpan ts;

    private void Start()
    {
        MainIcon = Data.Instance.MainWeapon.Icon;
        SubIcon = Data.Instance.SubWeapon.Icon;
        start = DateTime.Now;
    }

    private void Update()
    {
        ts = DateTime.Now - start;
        if (ts.Minutes > 50f)
        {
            start = DateTime.Now;
            StartCoroutine("EndMission");
        }
    }


    public void ToCompensation()
    {
        SceneMigration.Migrate(AnimaScene.Mission,AnimaScene.Compensation);
    }


    public void MissionClear()
    {
        StartCoroutine("ClearCoroutine");
    }

    private IEnumerator ClearCoroutine()
    {
        clear.SetActive(true);
        yield return new WaitForSeconds(5f);
        clear.GetComponentInChildren<Text>().text = "あと30秒で帰還します。";
        yield return new WaitForSeconds(5f);
        clear.SetActive(false);
        yield return new WaitForSeconds(25f);
        ToCompensation();
    }
}
