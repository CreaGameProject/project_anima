using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionNode : Node
{
    State nextState;

    TransitionNode(
        string nodeName, 
        string parentNodeName, 
        EvaluateValue evaluateValue, 
        NodeEffective nodeEffective, 
        State nextState
        ) : base(
            nodeName, 
            parentNodeName, 
            evaluateValue, 
            nodeEffective)
    {
        this.nextState = nextState;
    }

    public override Node NodeRun()
    {
        preyStatus.nodeManager.SetState(nextState);//優先度の考察が必要あり
        return this;

        throw new System.NotImplementedException();
    }
}
