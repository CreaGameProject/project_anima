using UnityEngine;
using UnityEngine.SceneManagement;

public enum AnimaScene {Title,Table,Base,Save,Weapon,WeaponEnhance,WeaponSelect,Fixture,Select,Mission,Compensation};

public class SceneMigration : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void Migrate(AnimaScene from,AnimaScene to)
    {
        SceneManager.UnloadSceneAsync((int)from);
        SceneManager.LoadSceneAsync((int)to, LoadSceneMode.Additive);
    }

    public static void LoadTable()
    {
        SceneManager.LoadSceneAsync((int)AnimaScene.Table, LoadSceneMode.Additive);
    }

    public static void UnLoadTable()
    {
        SceneManager.UnloadSceneAsync((int)AnimaScene.Table);
    }
}
