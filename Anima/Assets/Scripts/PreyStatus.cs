using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PreyStatus : MonoBehaviour
{
    public int hp;//HP
    [SerializeField]protected int hpMax;//最大HP
    public float vital;//体力
    public float vigilance;//警戒値
    [SerializeField]protected float visionCorrection;//視覚補正値
    [SerializeField]protected float hearingCorrection;//聴覚補正値
    [SerializeField]protected float olfactionCorrection;//嗅覚補正値
    public abstract int Vision();//視覚
    [SerializeField]public float visionAngle;//視野角
    public abstract int Hearing();//聴覚
    public abstract int Olfaction();//嗅覚
    public State state;//ステート記録
    public Dictionary<string, int> parts = new Dictionary<string, int>();//部位体力
    public Dictionary<State, NodeLibrary> nodeLibrary = new Dictionary<State, NodeLibrary>();//ノード入れるやつ
    private NodeManager nodeManager = new NodeManager();//ノードの管理、現在のノードの情報保持など

    // Start is called before the first frame update
    void Start()
    {
        LibrariesInitialize();
        StatusInitialize();
        
    }

    protected abstract void LibrariesInitialize();//ノードライブラリ格納
    protected virtual void StatusInitialize()//ステータス初期化
    {
        hp = hpMax;
        vital = 1;
        vigilance = 0;
        foreach(string i in parts.Keys)//各部位の体力全快
        {
            parts[i] = 1;
        }
        state = State.EXPLORING;//ステートを探索に設定
    }


    // Update is called once per frame
    void Update()
    {

    }
}
