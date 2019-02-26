using UnityEngine;

public class MissionManager : MonoBehaviour
{
    private Data data;
    private float timeLimit;
    public float damage;

    private void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<Data>();

    }


    public void ToCompensation()
    {
        SceneMigration.Migrate(AnimaScene.Compensation);
    }


    public void Taxikea()
    {
        Time.timeScale = 0.2f;
    }
}
