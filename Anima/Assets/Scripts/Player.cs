using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;

        float moveLength = speed * Time.smoothDeltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            curPos.x -= moveLength;
        }
        if (Input.GetKey(KeyCode.D))
        {
            curPos.x += moveLength;
        }
        if (Input.GetKey(KeyCode.W))
        {
            curPos.z += moveLength;
        }
        if (Input.GetKey(KeyCode.S))
        {
            curPos.z -= moveLength;
        }

        if(navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid)//パスが無効
        {
            Debug.Log("パスが無効");
            NavMeshHit hit = new NavMeshHit();
            if (NavMesh.SamplePosition(transform.position, out hit, 10.0f, NavMesh.AllAreas))//hit.positionに最も近いメッシュ上の座標を取得
            {
                transform.position = hit.position;
            }
            else
            {
                Debug.Log("navmeshが見つかりません");
            }
        }
        else//パスが有効
        {
            navMeshAgent.SetDestination(curPos);
        }
    }
}
