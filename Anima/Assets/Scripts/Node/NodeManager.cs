using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    private int frameSkip = 5;
    private Node curNode;
    public State curState { private set; get; }
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
        curNode = curNode.NodeRun();
        //再帰的にノードを連結させ、リーフノード(Action, Transition)にたどり着けばそのノード自体を返す。
        //探索は一瞬で終わるものと仮定して確認は行わない
        yield return new WaitForSeconds(frameSkip / 60);
        SetState(curState);
        yield break;
    }
}
