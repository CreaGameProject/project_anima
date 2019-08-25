using UnityEngine;

public class TitleManager: MonoBehaviour {

    private void Awake()
    {
        SceneMigration.LoadTable();
    }

    public void ToBase()
    {
        DataSave.WeaponLoad();
        DataSave.FixtureLoad();
        DataSave.MissionLoad();
        SceneMigration.Migrate(AnimaScene.Title,AnimaScene.Base);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
