using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 dest;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        // int layerMask = (1 << LayerMask.NameToLayer("HitPanel")); //適当なレイヤーマスクを設定するよ

        // if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        // {
        //     //レイが当たった位置を得るよ
        //     Vector3 pos = hit.point;
        // }

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
            navMeshAgent.SetDestination(dest);
        }
    }
}
