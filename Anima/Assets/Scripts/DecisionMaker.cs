using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 意思決定の土台
/// </summary>
public class DecisionMaker: MonoBehaviour
{

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private PreyStatus _preyStatus;
    private PatrolState _patrolState;
    private Perception _perception;
    
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _preyStatus = GetComponent<PreyStatus>();
        _patrolState = GetComponent<PatrolState>();
        _perception = GetComponent<Perception>();
        
        _patrolState.moveToPoint = MoveToPoint;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    protected IEnumerator RootState(Func<IEnumerator> findState)
    {
        // プレイヤー認識, あるいは発見した場合は巡回コルーチンを停止、強制ステート遷移する。
        while (true)
        {
            Coroutine patrol = StartCoroutine(_patrolState.PatrolStart());
            if (_preyStatus.hp <= 0)
            {
                StopCoroutine(patrol);
                yield return DeathState();
            }
            else if (_perception.perceptionLevel >= PerceptionLevel.Recognition)
            {
                StopCoroutine(patrol);
                yield return findState;
            }

            yield return null;
        }
    }

    protected IEnumerator DeathState()
    {
        //アニメーションの割り込み等
        while (true)
        {
            
        }
    }

    /// <summary> 特定の座標まで移動 </summary>
    /// <param name="reachDistance"> destinationまでたどり着いたと判定してもよい距離 </param>
    public IEnumerator MoveToPoint(Vector3 destination, float reachDistance){
        if(_navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid)//パスが無効
        {
            Debug.Log("パスが無効");
            yield break;
        }
        else//パスが有効
        {
            //Debug.Log("パスが有効");
            _navMeshAgent.SetDestination(destination);
            while (XZDistance(transform.position, destination) > reachDistance)
            {
                yield return null;
            }
            yield break;
        }
    }
    
    #region 諸関数

    /// <summary> 2座標間の平面距離を求める </summary>
    // ReSharper disable once InconsistentNaming
    public static float XZDistance(Vector3 v1, Vector3 v2)
    {
        v1 -= v2; v1.y = 0; return v1.magnitude;
    }

    #endregion

}
