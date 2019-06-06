using UnityEngine;

public class E_n_e_m_y : MonoBehaviour
{
    private byte state;
    private Vector3 beforePos;
    private Vector3 newPos;
    private Vector3 direction;

    [SerializeField] private float speed;

    private void Start()
    {
        Select();
        beforePos = transform.position = newPos;
    }

    void Update()
    {
        switch (state)
        {
            case 0:Select();break;
            case 1:Translate();break;
            default:break;
        }
    }

    private void Select()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);
        newPos = new Vector3(x, 1, z);
        state = 1;
    }

    private void Translate()
    {
        direction = (newPos - beforePos).normalized;

        if ((transform.position - newPos).magnitude > speed)
        {
            transform.Translate(direction * speed);
        }
        else
        {
            beforePos = newPos;
            state = 0;
        }
    }

    //クリアした瞬間
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().materials[0].color = Color.red;
        state = 2;
        GameObject.Find("MissionManager").GetComponent<MissionManager>().MissionClear();
    }
}
