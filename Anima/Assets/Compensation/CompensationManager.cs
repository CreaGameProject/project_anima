using UnityEngine;
using UnityEngine.UI;

public class CompensationManager : MonoBehaviour
{
    [SerializeField] private GameObject monitor1;
    [SerializeField] private GameObject monitor2;
    [SerializeField] private Text compensationValue;

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
        SceneMigration.LoadTable();
        foreach(Button button in GameObject.Find("materials").GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(() => {
                selecting = button.gameObject;
            });
        }
    }

    public void ToBase()
    {
        SceneMigration.MigrateReplacement(AnimaScene.Compensation,AnimaScene.Save);
    }

    public void Switch()
    {
        monitor1.SetActive(false);
        compensationValue.text =
            Data.Instance.selectedMission.Compensation.ToString() + "$" + System.Environment.NewLine +
            Data.Instance.materials[0].Number.ToString() + "$" + System.Environment.NewLine +
            System.Environment.NewLine +
            (Data.Instance.materials[0].Number += Data.Instance.selectedMission.Compensation).ToString() + "$";
        monitor2.SetActive(true);
    }
}
