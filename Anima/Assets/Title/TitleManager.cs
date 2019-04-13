using UnityEngine;

public class TitleManager: MonoBehaviour {
    
    public void ToBase()
    {
        DataSave.WeaponLoad();
        DataSave.FixtureLoad();
        DataSave.MissionLoad();
        SceneMigration.Migrate(AnimaScene.Base);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
