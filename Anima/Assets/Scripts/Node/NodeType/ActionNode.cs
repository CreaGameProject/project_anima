using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node
{
    bool interruptible;

    public ActionNode(string nodeName, string parentNodeName, EvaluateValue evaluateValue, NodeEffective nodeEffective, bool interruptible) : base(nodeName, parentNodeName, evaluateValue, nodeEffective)
    {
        this.interruptible = interruptible;
    }

    protected override Node NodeRun()
    {
        throw new System.NotImplementedException();
    }
}
