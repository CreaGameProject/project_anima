using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public string nodeName;
    public string parentNodeName;
    public NodeManager.NodeEffective nodeEffective;

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
