using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNode : Node
{
    protected override Node NodeRun()
    {
        float denominator = 0;//子ノードの評価値合計
        foreach(Node cNode in childNodes)
        {
            denominator += cNode.evaluateValue();
        }

        float probability = Random.Range(0, denominator);//[0, 子ノードの評価値の合計]から一つ値をとる
        float t = 0;//閾値
        for (int i = 0; i < childNodes.Count; i++)
        {
            t += childNodes[i].evaluateValue();//tに評価値を加算
            if(probability < t)
            {
                return childNodes[i];//probabilityがtを下回ったときそのノードが選ばれたとする。
            }
        }
        return childNodes[childNodes.Count - 1];//probability == t の場合の処理

        throw new System.NotImplementedException();//例外
    }
}
