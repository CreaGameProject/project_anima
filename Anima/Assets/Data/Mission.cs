using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Mission", menuName = "CreateMission")]
public class Mission : ScriptableObject
{
    //ミッション関連の数値庫

    //ミッション内容
    [SerializeField] private string content;

    //獲物の種類(Pleykind => Dataのenum)
    [SerializeField] private Preykind prey;

    //開放・未開放
    [SerializeField] private bool open;

    //報酬
    [SerializeField] private int compensation;

    //獲得素材
    [SerializeField] private Material[] acquisiton;



    //プロパティ
    public string Content { get { return content; } }
    public Preykind Prey { get { return prey; } }
    public bool Open { get { return open; }set { open = value; } }
    public int Compensation { get { return compensation; } }
    public Material[] Materials { get { return acquisiton; } }
}
