using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "CreateWeapon")]

public class Weapon : ScriptableObject
{
    //武器に関する固有値
    //固有値の変更は強化シーン


    //武器名
    [SerializeField] private string weaponName;

    //武器の種類(WeaponKind => Dataのenum)
    [SerializeField] private WeaponKind kind;

    //武器モデル
    [SerializeField] private GameObject model;

    //武器アイコン
    [SerializeField] private Sprite icon;


    //以下可変数値
    //所持・未所持
    [SerializeField] private bool possession;

    //初速
    [SerializeField] private float speed;

    //火力
    [SerializeField] private float power;

    //減衰
    [SerializeField] private float attenuation;

    //距離最大値
    [SerializeField] private float distance;

    //リロード時間
    [SerializeField] private float reload;

    //弾数最大値
    [SerializeField] private int strage;

    //最大弾丸保持数
    [SerializeField] private int retention;

    private char cord;
    public byte Cord { private get { return (byte)cord; } set { cord = (char)value; } }

    
    //プロパティ
    public WeaponKind Kind { get { return kind; } }
    public string Name { get { return weaponName; } }
    public GameObject Model { get { return model; } }
    public Sprite Icon { get { return icon; } }

    public bool Possession { get { return possession; } set { possession = value; } }
    public float Speed { get { return speed; } set { speed = value < 0 ? speed : value; } }
    public float Power { get { return power; } set { power = value < 0 ? power : value; } }
    public float Attenuation { get { return attenuation; } set { attenuation = value < 0 ? attenuation : value; } }
    public float Disatnce { get { return distance; } set { distance = value < 0 ? distance : value; } }
    public float Reload { get { return reload; } set { reload = value < 0 ? reload : value; } }
    public int Strage { get { return strage; } set { strage = value < 0 ? strage : value; } }
    public int Retention { get { return retention; }set { retention = value < 0 ? retention : value; } }


    //セーブ＆ロード
    public void Save()
    {
        PlayerPrefs.SetFloat(cord + "s", speed);
        PlayerPrefs.SetFloat(cord + "p", power);
        PlayerPrefs.SetFloat(cord + "a", attenuation);
        PlayerPrefs.SetFloat(cord + "d", distance);
        PlayerPrefs.SetFloat(cord + "r", reload);

        int temp = possession ? (strage + (retention << 16)) : -(strage + (retention << 16));
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
            retention = (-temp) >> 16;
        }
        else
        {
            possession = true;
            strage = temp & ushort.MaxValue;
            retention = temp >> 16;
        }
    }
}

