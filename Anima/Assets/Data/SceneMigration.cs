using UnityEngine;
using UnityEngine.SceneManagement;

public enum AnimaScene {Title,Base,Save,Weapon,Fixture,Select,Mission,Compensation};

public class SceneMigration : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void Migrate(AnimaScene to)
    {
        SceneManager.LoadSceneAsync((int)to, LoadSceneMode.Single);
    }
}
