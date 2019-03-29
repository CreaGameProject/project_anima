using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionNode : Node
{
    State nextState;

    TransitionNode(string nodeName, string parentNodeName, EvaluateValue evaluateValue, NodeEffective nodeEffective, State nextState) : base(nodeName, parentNodeName, evaluateValue, nodeEffective)
    {
        this.nextState = nextState;
    }

    protected override Node NodeRun()
    {
        preyStatus.nodeManager.SetState(nextState);
        return null;

        throw new System.NotImplementedException();
    }
}
