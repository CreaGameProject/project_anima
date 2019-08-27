using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    public void ToTitle()
    {
        SceneMigration.MigrateReplacement(AnimaScene.Base,AnimaScene.Title);
        Destroy(GameObject.Find("GameManager"));
    }

    public void ToSave()
    {
        SceneMigration.MigrateReplacement(AnimaScene.Base, AnimaScene.Save);
    }

    public void ToWeapon()
    {
        GameObject.Find("TableCamera").GetComponent<CameraAngle>().Base_to_Weapon();
    }


    public void ToFixture()
    {
        GameObject.Find("TableCamera").GetComponent<CameraAngle>().Base_to_Fixture();
    }

    public void ToMission()
    {
        GameObject.Find("TableCamera").GetComponent<CameraAngle>().Base_to_Select();
    }
}
