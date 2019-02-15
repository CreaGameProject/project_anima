using System.Collections;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    [SerializeField] private GameObject monitor1;
    [SerializeField] private GameObject monitor2;

    public void Save()
    {
        GameObject.Find("GameManager").GetComponent<Data>().SaveData();
        monitor1.SetActive(false);
        monitor2.SetActive(true);
    }

    public void ToBase()
    {
        SceneMigration.Migrate(AnimaScene.Base);
    }
}
