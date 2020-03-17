using UnityEngine;
using UnityEngine.SceneManagement;

public enum AnimaScene {Title,Table,Base,Save,Weapon,WeaponEnhance,WeaponSelect,Fixture,Select,Mission,Compensation};

public class SceneMigration : MonoBehaviour
{
    public static AnimaScene preScene;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void MigrateSingle(AnimaScene to)
    {
        SceneManager.LoadSceneAsync((int)to, LoadSceneMode.Single);
    }

    public static void MigrateReplacement(AnimaScene from,AnimaScene to)
    {
        SceneManager.LoadSceneAsync((int)to, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync((int)from);
    }

    public static void LoadTable()
    {
        if (SceneManager.GetSceneByBuildIndex((int)AnimaScene.Table).isLoaded == false)
        {
            SceneManager.LoadSceneAsync((int)AnimaScene.Table, LoadSceneMode.Additive);
        }
    }

    public static void UnLoadTable()
    {
        SceneManager.UnloadSceneAsync((int)AnimaScene.Table);
    }
}
