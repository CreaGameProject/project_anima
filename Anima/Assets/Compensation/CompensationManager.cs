using UnityEngine;
using UnityEngine.UI;

public class CompensationManager : MonoBehaviour
{
    [SerializeField] private GameObject monitor1;

    [SerializeField] private GameObject monitor2;
    [SerializeField] private GameObject buttonPrefab;
    private Transform materialParent;

    public GameObject selecting;
    public static CompensationManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        materialParent = GameObject.Find("materials").transform;
        for(int i = 0; i < 20; i++)
        {
            GameObject materialIcon = Instantiate(buttonPrefab, materialParent);
        }
        selecting = GameObject.Find("Button(Clone)");
    }

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
