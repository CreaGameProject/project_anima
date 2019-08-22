using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    public void ToTitle()
    {
        SceneMigration.Migrate(AnimaScene.Base,AnimaScene.Title);
        Destroy(GameObject.Find("GameManager"));
    }

    public void ToSave()
    {
        SceneMigration.Migrate(AnimaScene.Base, AnimaScene.Save);
    }

    public void ToWeapon()
    {
        StartCoroutine(GameObject.Find("TableCamera").GetComponent<CameraAngle>().Base_to_Weapon());
    }


    public void ToFixture()
    {
        SceneMigration.Migrate(AnimaScene.Base, AnimaScene.Fixture);
    }

    public void ToMission()
    {
        SceneMigration.Migrate(AnimaScene.Base, AnimaScene.Select);
    }
}
