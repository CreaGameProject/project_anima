using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Mission", menuName = "CreateMission")]
public class Mission : ScriptableObject
{
    //ミッション関連の数値庫

    //ミッション内容
    [SerializeField] private string content;
    public string Content { get { return content; } }

    //獲物の種類(Pleykind => Dataのenum)
    [SerializeField] private Preykind prey;
    public Preykind Prey { get { return prey; } }

    //開放・未開放
    [SerializeField] private bool open;
    public bool Open { get { return open; }set { open = value; } }

    //報酬
    [SerializeField] private int compensation;
    public int Compensation { get { return compensation; } }

    //獲得素材
    [SerializeField] private Material[] acquisiton;
    public Material[] Materials { get { return acquisiton; } }
    
}
