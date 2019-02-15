using UnityEngine;

public class MissionContent : MonoBehaviour
{
    public Mission mission;

    public void MissionDisplay()
    {
        GameObject.Find("GameManager").GetComponent<Data>().selectedMission = mission;
        GameObject.Find("SelectManager").GetComponent<SelectManager>().ContentDisplay();
    }

    private void Start()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = mission.Open;
    }
}
