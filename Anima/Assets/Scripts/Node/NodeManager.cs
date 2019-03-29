using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    private Node curNode;
    private State curState;
    private Dictionary<State, NodeLibrary> libraries;
    private List<Node> nodeLibrary = new List<Node>();
    public NodeManager(Dictionary<State, NodeLibrary> paramLibraries)//コンストラクタ
    {
        libraries = paramLibraries;//ノードライブラリコレクションを格納
    }

    public void SetState(State state)//ステートを強制的に変更し、ビヘイビアツリーをrootノードから開始する。
    {
        curState = state;
        curNode = libraries[curState].nodes.Find(a => a.nodeName == "root");
        StartCoroutine(NodeSend());
    }

    private IEnumerator NodeSend()//ノード送り
    {
        //memo どうやってウエイトをとるか
        //そもそもウエイトいるの？
        //ウエイトをとるノード→アクションノードのみ
        //基本的にアクションノードはそのまま次に進めた上で必要なのはトランジョン、怯み等の受付のみ
        //
        //オーバーロード
        //

        StartCoroutine(NodeSend());
        yield break;
    }
}
