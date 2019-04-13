using System.Collections;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    [SerializeField] private GameObject monitor1;
    [SerializeField] private GameObject monitor2;

    public void Save()
    {
        DataSave.WeaponSave();
        DataSave.FixtureSave();
        DataSave.MissionSave();
        monitor1.SetActive(false);
        monitor2.SetActive(true);
    }

    public void ToBase()
    {
        SceneMigration.Migrate(AnimaScene.Base);
    }
}
