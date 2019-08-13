using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{

    public void ToTitle()
    {
        SceneMigration.Migrate(AnimaScene.Title);
        Destroy(GameObject.Find("GameManager"));
    }

    public void ToSave()
    {
        SceneMigration.Migrate(AnimaScene.Save);
    }

    public void ToWeapon()
    {
        SceneMigration.Migrate(AnimaScene.Weapon);
    }

    public void ToFixture()
    {
        SceneMigration.Migrate(AnimaScene.Fixture);
    }

    public void ToMission()
    {
        SceneMigration.Migrate(AnimaScene.Select);
    }
}
