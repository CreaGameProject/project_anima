using UnityEngine;
using UnityEngine.UI;

public class CompensationManager : MonoBehaviour
{
    [SerializeField] private GameObject monitor1;
    [SerializeField] private GameObject monitor2;

    public void ToBase()
    {
        SceneMigration.Migrate(AnimaScene.Base);
    }

    public void Switch()
    {
        monitor1.SetActive(false);
        monitor2.SetActive(true);
    }
}
