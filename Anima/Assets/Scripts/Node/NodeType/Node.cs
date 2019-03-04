using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float EvaluateValue();
public delegate bool NodeEffective();

public abstract class Node : MonoBehaviour
{
    public GameObject preyObject;
    public string nodeName;
    public string parentNodeName;
    public List<Node> childNodes = new List<Node>();
    public EvaluateValue evaluateValue;
    public NodeEffective nodeEffective;
    //public Node NodeRun()
    //{
    //    return NodeSelect();
    //}
    protected abstract Node NodeRun();
}
