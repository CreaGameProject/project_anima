using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeLibrary : ScriptableObject//NodeLibraryインスタンス1つにつきツリー1つを格納
{
    public NodeLibrary(PreyStatus nodeOwner)//コンストラクタ
    {
        AddNodes();
        TreeGenerator();
        preyStatus = nodeOwner;
    }
    public PreyStatus preyStatus;
    public List<Node> nodes = new List<Node>();
    protected abstract void AddNodes();//継承先のスクリプトで各ノードを記述、nodesに格納。

    private void TreeGenerator()//各ノードに子ノードを設定してツリー構造を生成
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            nodes[i].childNodes.AddRange(nodes.FindAll(n => n.parentNodeName == nodes[i].nodeName));
            nodes[i].preyStatus = this.preyStatus;
        }
    }
}
