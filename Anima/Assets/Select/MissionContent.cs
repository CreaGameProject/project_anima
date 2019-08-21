using UnityEngine;
using UnityEngine.UI;

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
        this.gameObject.GetComponent<Button>().interactable = mission.Open;
        gameObject.GetComponentInChildren<Text>().text = mission.name;
    }
}
