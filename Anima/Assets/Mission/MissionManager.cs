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
    [SerializeField] private Text weaponName;

    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemyText;

    //制限時間管理(タキサイキアに影響されない)
    private DateTime start;
    private TimeSpan ts;

    private void Start()
    {
        StartCoroutine(FadeOut(GameObject.Find("fade").GetComponent<Image>()));
        //MainIcon = Data.Instance.MainWeapon.Icon;
        ////SubIcon = Data.Instance.SubWeapon.Icon;
        start = DateTime.Now;
        foreach(Prey_Number prey_ in Data.Instance.selectedMission.Prey)
        {
            for(int i = 0; i < prey_.number; i++)
            {
                GameObject enemy = Instantiate(_enemy);
                GameObject enemyText = Instantiate(_enemyText);
                enemyText.transform.SetParent(GameObject.Find("Canvas").transform);
                enemyText.GetComponent<Text>().text = prey_.PreyName;
                enemyText.GetComponent<T_e_x_t>().targetTfm = enemy.transform;
            }
        }
        weaponName.text = Data.Instance.MainWeapon.name;
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
        bool c = true;
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            c &= (e.GetComponent<E_n_e_m_y>().state == 2);
        }
        if (c)
        {
            StartCoroutine("ClearCoroutine");
        }
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
