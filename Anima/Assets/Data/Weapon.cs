using UnityEngine;
using UnityEngine.UI;
using System;

public enum WeaponKind { Rifle, Shotgun };

[Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "CreateWeapon")]
public class Weapon : ScriptableObject
{
    //武器に関する固有値
    //固有値の変更は強化シーン




    //武器モデル
    [SerializeField] private GameObject model;
    public GameObject Model { get { return model; } }

    //武器アイコン
    [SerializeField] private RawImage icon;
    public RawImage Icon { get { return icon; } }


    //以下可変数値
    //[0]=初期値 [1]=上げ幅

    //レベル -> 未所持=-1;
    [SerializeField] private int level;
    public int Level { get { return level; } set { level = value; } }

    //初速
    public float[] speed;
    public float Speed { get { if (speed.Length > 1) { return speed[0] + speed[1] * level; } else { return speed[0]; } } }

    //火力
    public float[] power;
    public float Power { get { if (power.Length > 1) { return power[0] + power[1] * level; } else { return power[0]; } } }

    //距離最大値
    public float[] distance;
    public float Disatnce { get { if (distance.Length > 1) { return distance[0] + distance[1] * level; } else { return distance[0]; } } }

    //リロード時間
    public float[] reload;
    public float Reload { get { if (reload.Length > 1) { return reload[0] + reload[1] * level; } else { return reload[0]; } } }

    //減衰
    public float attenuation;
    public float Attenuation { get { return attenuation; } }

    //弾数最大値
    public int[] strage;
    public int Strage { get { if (strage.Length > 1) { return strage[0] + strage[1] * level; } else { return strage[0]; } } }

    //最大弾丸保持数
    public int[] retention;
    public int Retention { get { if (retention.Length > 1) { return retention[0] + retention[1] * level; } else { return retention[0]; } } }

}


