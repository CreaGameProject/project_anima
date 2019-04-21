using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    //内容は未定、アクションノードがPreyStatusの行動予約を変えるために渡すクラス
}

public class ActionNode : Node
{
    int priority;

    public ActionNode(
        string nodeName, 
        string parentNodeName, 
        EvaluateValue evaluateValue, 
        NodeEffective nodeEffective, 
        int priority
        ) : base(
            nodeName, 
            parentNodeName, 
            evaluateValue, 
            nodeEffective)
    {
        this.priority = priority;
    }

    public override Node NodeRun()
    {
        return this;
    }
}
