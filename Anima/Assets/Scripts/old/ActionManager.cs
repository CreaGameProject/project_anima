using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActionManager : MonoBehaviour
{
    // アニメーションにステートを用意する
    // どこから遷移させるか
    // ActionManager?
    [SerializeField] float nearJudgeDistance = 30;

    Animator ac;
    NavMeshAgent na;
    Vector3 currentPos;
    
    

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<Animator>();
        na = GetComponent<NavMeshAgent>();
        currentPos = transform.position;
    }

    public void WalkAnimation(bool walk){
        ac.SetBool("Walking", walk);
    }

    public IEnumerator SetAction(){
        yield break;
    }

    //特定の目的地に移動する
    private IEnumerator MoveToPoint(Vector3 destination, float speed = -1f, float angularSpeed = -1f, float acceleration = -1f, float stoppingDistance = -1f){
        na.speed = speed == -1 ? na.speed : speed;
        na.angularSpeed = angularSpeed == -1 ? na.angularSpeed : angularSpeed;
        na.acceleration = acceleration == -1 ? na.acceleration : acceleration;
        na.stoppingDistance = stoppingDistance == -1 ? na.stoppingDistance : stoppingDistance;
        na.SetDestination(destination);
        while(MoveFinishJudge(destination)){
            yield return null;
        }
        yield break;
    }

    //目的座標に到達したとみなせるならtrue
    private bool MoveFinishJudge(Vector3 destination){
        destination -= transform.position;
        destination.y = 0;
        return destination.magnitude < nearJudgeDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPos != transform.position){
            ac.SetBool("Walking", true);
        } else {
            ac.SetBool("Walking", false);
        }
    }
}
