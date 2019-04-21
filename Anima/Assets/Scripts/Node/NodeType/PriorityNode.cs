using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityNode : Node
{
    public PriorityNode(
        string nodeName, 
        string parentNodeName, 
        EvaluateValue evaluateValue, 
        NodeEffective nodeEffective
        ) : base(
            nodeName, 
            parentNodeName, 
            evaluateValue, 
            nodeEffective
            ){ }

    public override Node NodeRun()
    {
        List<Node> nextNode = new List<Node>();//遷移先ノード候補
        float maxValue = childNodes[0].evaluateValue();//最大評価値を子ノードインデックス0で初期化
        foreach(Node node in childNodes)//最大評価値を更新
        {
            if(node.evaluateValue() > maxValue)
            {
                maxValue = node.evaluateValue();
            }
        }
        nextNode = childNodes.FindAll(n => n.evaluateValue() == maxValue);//遷移先ノードを格納
        return nextNode[Random.Range(0,nextNode.Count)].NodeRun();//一つに絞り込み次のノードを実行

        throw new System.NotImplementedException();//例外処理
    }
}
