using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public void ToCompensation()
    {
        SceneMigration.Migrate(AnimaScene.Compensation);
    }
}
