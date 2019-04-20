using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MissionManager : MonoBehaviour
{
    public float damage;
    [SerializeField] private RawImage MainIcon;
    [SerializeField] private RawImage SubIcon;
    private byte taxikeaCount;

    //制限時間管理(タキサイキアに影響されない)
    private DateTime start;
    private TimeSpan ts;

    private void Start()
    {
        MainIcon = Data.Instance.MainWeapon.Icon;
        SubIcon = Data.Instance.SubWeapon.Icon;
        taxikeaCount = 3;
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
        SceneMigration.Migrate(AnimaScene.Compensation);
    }

    public IEnumerator Taxikea()
    {
        if (taxikeaCount > 0)
        {
            //主人公の能力値が変わったり、
            //環境変化があったり
            Time.timeScale = 0.2f;

            yield return new WaitForSecondsRealtime(7f);

            //元に戻す。
            Time.timeScale = 1f;
            taxikeaCount--;
        }
    }

    private IEnumerator EndMission()
    {
        yield return new WaitForSeconds(30f);
        //ゲーム終了
    }
}
