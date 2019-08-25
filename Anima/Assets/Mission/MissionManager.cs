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
        StartCoroutine(FadeOut(GameObject.Find("fade").GetComponent<Image>()));
        MainIcon = Data.Instance.MainWeapon.Icon;
        //SubIcon = Data.Instance.SubWeapon.Icon;
        start = DateTime.Now;
    }

    IEnumerator FadeOut(Image fade)
    {
        for(float i = 0; i < 60; i++)
        {
            yield return null;
            fade.color = Color.Lerp(Color.black, Color.clear, i / 60f);
        }
        Destroy(fade.gameObject);
    }

    private void Update()
    {
        ts = DateTime.Now - start;
        if (ts.Minutes > 50f)
        {
            start = DateTime.Now;
        }
    }


    public void ToCompensation()
    {
        SceneMigration.MigrateSingle(AnimaScene.Compensation);
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
        yield return new WaitForSeconds(5f);
        ToCompensation();
    }
}
