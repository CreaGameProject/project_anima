using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionNode : Node
{
    State nextState;

    TransitionNode(string nodeName, string parentNodeName, State nextState)
    {
        this.nodeName = nodeName;
        this.parentNodeName = parentNodeName;
        this.nextState = nextState;
    }

    protected override Node NodeRun()
    {
        preyStatus.nodeManager.SetState(nextState);

        throw new System.NotImplementedException();
    }
}
