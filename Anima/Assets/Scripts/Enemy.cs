using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class PatrolPoint{//巡回地点のクラス
        [SerializeField] public float satisfaction = 1; //満足度 満腹度ともいう
        [SerializeField] private float satisfyRatio = 0.7f; //satisfactionがこれを超えるとほかの地点に移動できるようになる。
        [SerializeField] private Vector3 center;//中心
        [SerializeField] private float radius;//半径 必ず移動可能な範囲で設定すること
        [SerializeField] public Vector3 destination;　//一度ランダマイズして決定された座標はその場所にたどり着くまで保存される。

        //コンストラクタ　実際なくていいかも
        public PatrolPoint(Vector2 center, float radius, float satisfyRatio){
            this.satisfyRatio = satisfyRatio;
            this.center = center;
            this.radius = radius;
            randomDestination(0);
        }

        //ある座標が巡回地点範囲内にあればtrue
        public bool OnPoint(Vector3 position){
            Vector3 judge = position - center;
            judge.y = 0;
            return judge.magnitude < radius;
        }

        //目的地のランダマイズ
        public Vector3 randomDestination(float y){
            float r = Random.Range(0, radius);
            float t = Random.Range(0, 2 * Mathf.PI);
            float x = r * Mathf.Cos(t) + center.x;
            float z = r * Mathf.Sin(t) + center.z;
            return destination = new Vector3(x,y,z);
        }

        //ほかのPatrolPointに遷移可能か
        public bool CanTransition(){
            return satisfaction > satisfyRatio;
        }

        //腹減りの処理 正で減少
        public void Hunger(float hungry){
            satisfaction = Mathf.Clamp(satisfaction - hungry, 0, 1);
        }
    }

    [System.Serializable]
    public class State{
        [SerializeField] private string stateName;
    }

    //基本的に "hungy" <-> "satisfy"
    [SerializeField] private float hungerSpeed; //腹が減る速度
    [SerializeField] private float satisfySpeed; //腹が満たされる速度
    [SerializeField] private List<PatrolPoint> patrolPoints = new List<PatrolPoint>(); //敵が持つ巡回地点のリスト
    [SerializeField] private int nowPatPointInd; //現在の巡回地点
    [SerializeField] private float distance; //現在の巡回地点との距離

    private NavMeshAgent navMeshAgent;
//    private AnimationManager am;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
//        am = GetComponent<AnimationManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        SatiisfySelector();

    }

    //巡回地点を選択する
    public void SatiisfySelector(){
        float deltime = Time.deltaTime;
        float min = 1;
        int index = 0;
        //腹減り処理&最小満足度の巡回地点を選択
        for(int i = 0; i < patrolPoints.Count; i++){
            patrolPoints[i].Hunger(deltime * hungerSpeed);
            if(patrolPoints[i].satisfaction < min){
                min = patrolPoints[i].satisfaction;
                index = i;
            }
        }
        //現在の巡回地点が十分満たされている(遷移可能)なら巡回地点を選びなおし
        if(patrolPoints[nowPatPointInd].CanTransition()){
            if(nowPatPointInd != index){
                patrolPoints[index].randomDestination(transform.position.y);
            }
            nowPatPointInd = index;
        }

        //ある巡回地点における具体的な移動座標の算出&移動
        SatisfyBehave(patrolPoints[nowPatPointInd]);
        
        //満腹度回復処理
        if(patrolPoints[nowPatPointInd].OnPoint(transform.position)){
            patrolPoints[nowPatPointInd].Hunger(-satisfySpeed*deltime);
        }
    }

    //ある巡回地点における具体的な移動座標の算出&移動
    public void SatisfyBehave(PatrolPoint pp){
        Vector3 judge = pp.destination - transform.position;
        judge.y = 0;
        distance = judge.magnitude;
        if(judge.magnitude < 30.0f){
            if(Random.Range(0.0f, 1.0f) > 0.7)
            {
//                am.WalkAnimation(true);
                Debug.Log("移動");
                pp.randomDestination(transform.position.y);
            } else {
//                am.WalkAnimation(false);
                Debug.Log("止まる");
                pp.destination = transform.position;
            }
        }
        MoveToPoint(pp.destination);
    }

    //NavMeshを利用した移動 パスが存在すればtrue
    public bool MoveToPoint(Vector3 destination){
        if(navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid)//パスが無効
        {
            Debug.Log("パスが無効");
            NavMeshHit hit = new NavMeshHit();
            if (NavMesh.SamplePosition(transform.position, out hit, 10.0f, NavMesh.AllAreas))//hit.positionに最も近いメッシュ上の座標を取得
            {
                Debug.Log("パスを発見");
                navMeshAgent.SetDestination(hit.position);
            }
            else
            {
                Debug.Log("navmeshが見つかりません");
                return false;
            }
        }
        else//パスが有効
        {
            //Debug.Log("パスが有効");
            navMeshAgent.SetDestination(destination);
        }
        return true;
    }
}
