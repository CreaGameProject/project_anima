using UnityEngine;

public class TitleManager: MonoBehaviour {
    
    public void ToBase()
    {
        GameObject.Find("GameManager").GetComponent<Data>().LoadData();
        SceneMigration.Migrate(AnimaScene.Base);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
