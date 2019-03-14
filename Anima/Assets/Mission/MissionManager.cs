using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MissionManager : MonoBehaviour
{
    private Data data;
    public float damage;
    [SerializeField] private RawImage icon;

    //制限時間管理(タキサイキアに影響されない)
    private DateTime start;
    private TimeSpan ts;

    private void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<Data>();
        icon = data.MainWeapon.Icon;
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

    public void Taxikea(bool b)
    {
        if (b)
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private IEnumerator EndMission()
    {
        yield return new WaitForSeconds(30f);
        //ゲーム終了
    }
}
