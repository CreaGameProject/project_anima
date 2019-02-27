using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyStatus : MonoBehaviour
{
    int hp;//HP
    int hpMax;//最大HP
    float vital;//体力
    float vigilance;//警戒値
    int visionRange;//視覚距離
    int visionAngle;//視野角
    int hearing;//聴覚
    int olfaction;//嗅覚
    State state;
    Dictionary<string, int> parts = new Dictionary<string, int>();
    public Dictionary<State, NodeLibrary> nodeLibrary = new Dictionary<State, NodeLibrary>();
    // Start is called before the first frame update
    void Start()
    {
        state = State.EXPLORING;
        List<NodeLibrary> attachedLibraries = new List<NodeLibrary>();
        attachedLibraries.AddRange(GetComponents<NodeLibrary>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
