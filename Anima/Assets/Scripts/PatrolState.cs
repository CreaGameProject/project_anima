using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

/// <summary>
/// もともとDecisionMakerの一部
/// 機能分散のため分割した。
/// </summary>
public class PatrolState : MonoBehaviour
{
    // コンポーネント格納用
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    
    // Animator用のハッシュ
    private static readonly int Walking = Animator.StringToHash("Walking");
    
    // DecisionMakerから借りてくる関数
    /// <summary> 特定の座標まで移動 </summary>
    /// <param name="reachDistance"> destinationまでたどり着いたと判定してもよい距離 </param>
    public delegate IEnumerator MoveToPoint(Vector3 destination, float reachDistance);
    public MoveToPoint moveToPoint;

    // parameters
    /// <summary> 巡回中移動を選択する確率 </summary>
    [SerializeField] private float probabilityOfMove = 0.6f;
    /// <summary> 満腹度減少速度 </summary>
    [SerializeField] private float hungerSpeed;
    /// <summary> 満腹度回復速度 </summary>
    [SerializeField] private float satisfySpeed;
    /// <summary> 穢物がもつ巡回地点のリスト </summary>
    [SerializeField] private List<PatrolPoint> patrolPoints = new List<PatrolPoint>();
    /// <summary> MoveToPointの引数用 どこまで目標座標まで近づけばたどり着いたとするか </summary>
    [SerializeField] private float reachedDistance;
    /// <summary> 歩く速さ </summary>
    [SerializeField] private float walkSpeed;
    /// <summary> 巡回中待機が選択されたとき待つ時間 </summary>
    [SerializeField] private float waitTime;
    
    /// <summary> 現在の巡回地点 </summary>
    private PatrolPoint nowPatrol;

    /// <summary> 一つの巡回地点を表現するクラス </summary>
    [System.Serializable]
    public class PatrolPoint{
        /// <summary> 満足度 満腹度ともいう </summary>
        [SerializeField] public float satisfaction = 1;
        /// <summary> satisfactionがこれを超えるとほかの地点に移動できるようになる。 </summary>
        [SerializeField] private float satisfyThreshold = 0.7f;
        /// <summary> PatrolPointの中心座標 </summary>
        [SerializeField] private Vector3 center;
        /// <summary> 半径 必ず移動可能な範囲で設定すること(壁の中とか含んだらだめ) </summary>
        [SerializeField] private float radius;
        /// <summary> 現在の移動先座標 </summary>
        [SerializeField] public Vector3 destination;

        /// <summary> ある座標が巡回地点範囲内にあればtrue </summary>
        public bool OnPoint(Vector3 position)
        {
            return DecisionMaker.XZDistance(position, center) < radius;
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
    
    /// <summary> PatrolStateの本体 </summary>
    public IEnumerator PatrolStart()
    {
        _navMeshAgent.speed = walkSpeed;
        while (true)
        {
            if (Random.Range(0f, 1f) < probabilityOfMove)
            {
                Debug.Log("Prey Move!!");
                yield return PatrolMove();
            }
            else
            {
                Debug.Log("Prey Wait!!");
                yield return PatrolWait();
            }
        }
    }

    /// <summary> PatrolPointを選択し、移動先を算出、移動する </summary>
    private IEnumerator PatrolMove()
    {
        nowPatrol = SatisfySelector();
        _animator.SetBool(Walking, true);
        yield return moveToPoint(nowPatrol.destination, reachedDistance);
        _animator.SetBool(Walking, false);
        yield break;
    }

    /// <summary> PatrolPointへの移動を一回休み </summary>
    private IEnumerator PatrolWait()
    {
        yield return new WaitForSeconds(waitTime);
        yield break;
    }
    
    /// <summary> 最小満腹度の巡回地点を選択、具体的な移動先決定 </summary>
    /// <returns>選択されたPatrolPoint(移動先座標ランダマイズ済み</returns>
    private PatrolPoint SatisfySelector(){
        // ほかの巡回地点に遷移不可能なら移動先を再抽選
        if (nowPatrol != null)// null check
        {
            if (nowPatrol.CanTransition() == false)
            {
                nowPatrol.RandomDestination();
                return nowPatrol;
            }
        }
        
        // ほかの巡回地点に遷移可能ならPatrolPointを再選択
        PatrolPoint pointOfMinSatisfaction = patrolPoints[0];
        for(int i = 1; i < patrolPoints.Count; i++){
            if(patrolPoints[i].satisfaction < pointOfMinSatisfaction.satisfaction)
            {
                pointOfMinSatisfaction = patrolPoints[i];
            }
        }
        
        // 具体的な移動先をランダマイズで決定
        pointOfMinSatisfaction.RandomDestination();
        return pointOfMinSatisfaction;
    }

    /// <summary> 満腹度の回復、消費　引数のPatrolPoint領域内であれば回復する </summary>
    /// <param name="pp">現在の移動目標のPatrolPoint</param>
    private void Satisfy(PatrolPoint pp){
        // 消費
        float deltaTime = Time.deltaTime;
        foreach (var patrolPoint in patrolPoints)
        {
            patrolPoint.Hunger(deltaTime * hungerSpeed);
        }
        
        // 回復
        if (pp != null)
        {
            if (pp.OnPoint(transform.position))
            {
                pp.Hunger(-satisfySpeed*deltaTime);
            }
        }
    }
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Satisfy(nowPatrol);
    }
}
