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



    //武器の種類
    [SerializeField] private WeaponKind kind;
    public WeaponKind Kind { get { return kind; } }

    //武器モデル
    [SerializeField] private GameObject model;
    public GameObject Model { get { return model; } }

    //武器アイコン
    [SerializeField] private RawImage icon;
    public RawImage Icon { get { return icon; } }


    //以下可変数値
    //所持・未所持
    [SerializeField] private bool possession;
    public bool Possession { get { return possession; } set { possession = value; } }

    //レベル
    [SerializeField] private byte level;
    public byte Level { get { return level; }set { level = value; } }

    //初速
    [SerializeField] private float speed;
    public float Speed { get { return speed; } set { speed = value < 0 ? speed : value; } }

    //火力
    [SerializeField] private float power;
    public float Power { get { return power; } set { power = value < 0 ? power : value; } }

    //減衰
    [SerializeField] private float attenuation;
    public float Attenuation { get { return attenuation; } set { attenuation = value < 0 ? attenuation : value; } }

    //距離最大値
    [SerializeField] private float distance;
    public float Disatnce { get { return distance; } set { distance = value < 0 ? distance : value; } }

    //リロード時間
    [SerializeField] private float reload;
    public float Reload { get { return reload; } set { reload = value < 0 ? reload : value; } }

    //弾数最大値
    [SerializeField] private int strage;
    public int Strage { get { return strage; } set { strage = value < 0 ? strage : value; } }

    //最大弾丸保持数
    [SerializeField] private int retention;
    public int Retention { get { return retention; }set { retention = value < 0 ? retention : value; } }

    private char cord;
    public byte Cord { private get { return (byte)cord; } set { cord = (char)value; } }



    //セーブ＆ロード
    public void Save()
    {
        PlayerPrefs.SetFloat(cord + "s", speed);
        PlayerPrefs.SetFloat(cord + "p", power);
        PlayerPrefs.SetFloat(cord + "a", attenuation);
        PlayerPrefs.SetFloat(cord + "d", distance);
        PlayerPrefs.SetFloat(cord + "r", reload);

        int temp = possession ? (strage + (retention << 12) + (level << 24)) : -(strage + (retention << 12) + (level << 24));
        PlayerPrefs.SetInt(cord + "S", temp);
    }

    public void Load()
    {
        speed = PlayerPrefs.GetFloat(cord + "s", speed);
        power = PlayerPrefs.GetFloat(cord + "p", power);
        attenuation = PlayerPrefs.GetFloat(cord + "a", attenuation);
        distance = PlayerPrefs.GetFloat(cord + "d", distance);
        reload = PlayerPrefs.GetFloat(cord + "r", reload);

        int temp = PlayerPrefs.GetInt(cord + "S", -strage);
        if (temp < 0)
        {
            possession = false;
            strage = (-temp) & ushort.MaxValue;
            retention = ((-temp) >> 12) & ushort.MaxValue;
            level = (byte)((-temp) >> 24);
        }
        else
        {
            possession = true;
            strage = temp & ushort.MaxValue;
            retention = (temp >> 12) & ushort.MaxValue;
            level = (byte)(temp >> 24);
        }
    }
}

