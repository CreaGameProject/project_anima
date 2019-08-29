using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

/// <summary>
/// もともとDecisionMakerの一部
/// 機能分散のため分割した。
/// </summary>
public class PatrolState : MonoBehaviour
{
    
    [SerializeField] private float probabilityOfMove = 0.6f; //巡回中移動を選択する確率
    
    
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    
    /// <summary> 特定の座標まで移動 </summary>
    /// <param name="reachDistance"> destinationまでたどり着いたと判定してもよい距離 </param>
    public delegate IEnumerator MoveToPoint(Vector3 destination, float reachDistance);
    public MoveToPoint moveToPoint;

    // parameters
    [SerializeField] private float hungerSpeed; //腹が減る速度
    [SerializeField] private float satisfySpeed; //腹が満たされる速度
    [SerializeField] private List<PatrolPoint> patrolPoints = new List<PatrolPoint>(); //敵が持つ巡回地点のリスト
    [SerializeField] private int nowPatPointInd; //現在の巡回地点
    [SerializeField] private float distance; //現在の巡回地点との距離

    public bool endPatrol { get; private set; } = true;

    [System.Serializable]
    public class PatrolPoint{//巡回地点のクラス
        [SerializeField] public float satisfaction = 1; //満足度 満腹度ともいう
        [SerializeField] private float satisfyThreshold = 0.7f; //satisfactionがこれを超えるとほかの地点に移動できるようになる。
        [SerializeField] private Vector3 center;//中心
        [SerializeField] private float radius;//半径 必ず移動可能な範囲で設定すること
        [SerializeField] public Vector3 destination;　//現在の目標地点

        /// <summary> ある座標が巡回地点範囲内にあればtrue </summary>
        public bool OnPoint(Vector3 position){
            Vector3 judge = position - center;
            judge.y = 0;
            return judge.magnitude < radius;
        }
        
        /// <summary> 目的地のランダマイズ </summary>
        public Vector3 RandomDestination(){
            float r = Random.Range(0, radius);
            float t = Random.Range(0, 2 * Mathf.PI);
            float x = r * Mathf.Cos(t) + center.x;
            float z = r * Mathf.Sin(t) + center.z;
            return destination = new Vector3(x,0,z);
        }

        /// <summary> ほかのPatrolPointに遷移可能か </summary>
        public bool CanTransition(){
            return satisfaction > satisfyThreshold;
        }

        /// <summary> 腹減りの処理 正で減少 </summary>
        /// <param name="hungry">腹減り値</param>
        public void Hunger(float hungry){
            satisfaction = Mathf.Clamp(satisfaction - hungry, 0, 1);
        }
        
        
    }
    
    //

    public IEnumerator PatrolStart()
    {
        while (true)
        {
            
        }
        if (Random.Range(0f, 1f) < probabilityOfMove)
        {
            
        }
        else
        {
            
        }
    }
    
    //巡回地点を選択する
    public void SatiisfySelector(){
        //腹減り処理 & 最小満足度の巡回地点を選択
        float deltime = Time.deltaTime;
        float min = 1;
        int indexOfMinSatisfaction = 0;
        for(int i = 0; i < patrolPoints.Count; i++){
            patrolPoints[i].Hunger(deltime * hungerSpeed);
            if(patrolPoints[i].satisfaction < min){
                indexOfMinSatisfaction = i;
            }
        }
        //現在の巡回地点が十分満たされている(遷移可能)なら巡回地点を選びなおし
        if(patrolPoints[nowPatPointInd].CanTransition()){
            //現在の地点が
            if(nowPatPointInd != indexOfMinSatisfaction){
                patrolPoints[indexOfMinSatisfaction].RandomDestination();
            }
            nowPatPointInd = indexOfMinSatisfaction;
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
                pp.RandomDestination();
            } else {
//                am.WalkAnimation(false);
                Debug.Log("止まる");
                pp.destination = transform.position;
            }
        }
        //moveToPoint(pp.destination, distance);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
