using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public delegate bool NodeEffective();
    private Node currentNode;
    private List<Node> nodeLibrary = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        currentNode = nodeLibrary.Find(a => a.nodeName == "root");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLibrary(NodeLibrary nodeLibrary)
    {

    }
}
