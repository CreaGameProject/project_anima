
using UnityEngine;

public class Test : MonoBehaviour {
    
    public void ToBase()
    {
        SceneMigration.Migrate(AnimaScene.Base);
    }

    public void Plus()
    {
        GameObject.Find("GameManager").GetComponent<Data>().weapons[0].Strage += 10;
    }
}
