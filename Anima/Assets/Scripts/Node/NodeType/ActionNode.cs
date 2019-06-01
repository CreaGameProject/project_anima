using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action//ActionNode→PreyerStatusへ行動予約として渡す。
{
    public Vector3 movement { get; private set; }
    public Animation animation { get; private set; }
    Action(Vector3 movement, Animation animation)
    {
        this.movement = movement;
        this.animation = animation;
    }
}

public class ActionNode : Node
{
    int priority;
    Action action;

    public ActionNode(//何やこの引数の書き方！？
        string          nodeName, 
        string          parentNodeName, 
        EvaluateValue   evaluateValue, 
        NodeEffective   nodeEffective, 
        int             priority,
        Action          action
        ) : base(
            nodeName, 
            parentNodeName, 
            evaluateValue, 
            nodeEffective)
    {
        this.priority = priority;
        this.action = action;
    }

    public override Node NodeRun()
    {
        return this;
    }
}
