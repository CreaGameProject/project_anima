using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float EvaluateValue();
public delegate bool NodeEffective();

public abstract class Node : MonoBehaviour
{
    public Node(string nodeName, string parentNodeName, EvaluateValue evaluateValue, NodeEffective nodeEffective)
    {
        this.nodeName = nodeName;
        this.parentNodeName = parentNodeName;
        this.evaluateValue = evaluateValue;
        this.nodeEffective = nodeEffective;
    }

    //コンストラクタで初期化
    public string nodeName;//ノードの名前
    public string parentNodeName;//親ノード名前
    public EvaluateValue evaluateValue;//評価値算出
    public NodeEffective nodeEffective;//ノード

    //-----------------------------------------------
    //NodeManagerで初期化
    public PreyStatus preyStatus;
    public List<Node> childNodes = new List<Node>();

    //継承先で次のノード選択、実行を記述
    public abstract Node NodeRun();
}
