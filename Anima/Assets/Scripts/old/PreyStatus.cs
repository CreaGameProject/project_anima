using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    DEATH, EXPLORING, VIGILANCE, SEARCH, DISCOVERED
}

public class PreyStatus : MonoBehaviour
{

    public int hp;//HP
    // [SerializeField]protected int hpMax;//最大HP
    // public float vital;//スタミナ
    // public float vigilance;//警戒値
    // [SerializeField]protected float visionCorrection;//視覚補正値
    // [SerializeField]protected float hearingCorrection;//聴覚補正値
    // [SerializeField]protected float olfactionCorrection;//嗅覚補正値
    // public abstract int Vision();//視覚
    // [SerializeField]public float visionAngle;//視野角
    // public abstract int Hearing();//聴覚
    // public abstract int Olfaction();//嗅覚
    // public Dictionary<string, int> parts = new Dictionary<string, int>();//部位体力
    // //public Dictionary<EnvSpot, float> satisfy;//満足度
    // public Dictionary<State, NodeLibrary> nodeLibraries = new Dictionary<State, NodeLibrary>();//ノードライブラリとステートを関連付け、コレクションに格納

    // public NodeManager nodeManager;//ノードの管理、現在のノードの情報保持など

    // // Start is called before the first frame update
    // void Start()
    // {
    //     LibrariesInitialize();
    //     StatusInitialize();
    //     NodeManagerSetup();
    // }
}
