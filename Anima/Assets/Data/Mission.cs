using UnityEngine;
using System;

public enum Preykind { Deer, Bear, Boar };

[Serializable]
public class Prey_Number
{
    public Preykind prey;
    public string PreyName
    {
        get
        {
            switch (prey)
            {
                case Preykind.Deer:return "鹿";
                case Preykind.Bear:return "熊";
                case Preykind.Boar:return "猪";
                default:return "";
            }
        }
    }
    public int number;
}

[Serializable]
[CreateAssetMenu(fileName = "Mission", menuName = "CreateMission")]
public class Mission : ScriptableObject
{
    //ミッション関連の数値庫

    //制限時間
    [SerializeField] private float limit;
    public float Limit { get { return limit; } set { limit = value; } }

    //獲物の種類(Pleykind => Dataのenum)
    [SerializeField] private Prey_Number[] prey;
    public Prey_Number[] Prey { get { return prey; } }

    //開放・未開放
    [SerializeField] private bool open;
    public bool Open { get { return open; }set { open = value; } }

    //報酬
    [SerializeField] private int compensation;
    public int Compensation { get { return compensation; } }

    //獲得素材
    [SerializeField] private Material[] acquisiton;
    public Material[] Materials { get { return acquisiton; } }

    //クリア済
    [SerializeField] private bool clear;
    public bool Clear { get { return clear; } set { clear = clear || value; } }
}

