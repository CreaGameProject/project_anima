using UnityEngine;
using System;


public enum WeaponKind { Rifle, Shotgun };
public enum Preykind { Deer, Bear, Boar };
public enum ItemName { RifleBullet,ShotgunBullet};
public enum MaterialName { Money};


public class Data : MonoBehaviour
{
    public Weapon[] weapons;
    public Level[] levels;
    public Item[] Items;
    public Material[] Materials;

    public Weapon MainWeapon;
    public Weapon SubWeapon;
    public Mission selectedMission;
    public Item[] takeItems;


    //データのセーブ
    public void SaveData()
    {
        foreach(Weapon w in weapons)
        {
            w.Save();
        }
        for(int k = 0; k < levels.Length; k++)
        {
            int temp = 0;
            for (byte i = 0; i < levels.Length; i++)
            {
                if (levels[i].Open)
                {
                    temp += (1 << i);
                }
            }
            PlayerPrefs.SetInt("l", temp);
        }
        foreach(Level l in levels)
        {
            l.Save();
        }
        foreach(Item i in Items)
        {
            i.Save();
        }
        foreach(Material m in Materials)
        {
            m.Save();
        }

        PlayerPrefs.Save();
    }

    //データのロード
    public void LoadData()
    {
        for (byte w = 0; w < weapons.Length; w++)
        {
            weapons[w].Cord = w;
            weapons[w].Load();
        }
        int temp = PlayerPrefs.GetInt("l", 1);
        for (byte i = 0; i < levels.Length; i++)
        {
            levels[i].Cord = i;
            if ((temp >> i) == 1)
            {
                levels[i].Open = true;
            }
        }
        foreach (Level l in levels)
        {
            l.Load ();
        }
        for (byte i = 0; i < Items.Length; i++)
        {
            Items[i].Cord = i;
            Items[i].Load();
        }
        for (byte m = 0; m < Materials.Length; m++)
        {
            Materials[m].Cord = m;
            Materials[m].Load();
        }
    }
}

[Serializable]
public class Level
{
    private char cord;
    public byte Cord { private get { return (byte)cord; } set { cord = (char)value; } }
    public Mission[] missions;
    [SerializeField] private bool open;

    public bool Open { get { return open; } set { open = value; } }

    public void Save()
    {
        int temp = 0;
        for (byte i = 0; i < missions.Length; i++)
        {
            if (missions[i].Open)
            {
                temp += (1 << i);
            }
        }

        PlayerPrefs.SetInt("l" + cord, temp);
    }

    public void Load()
    {
        int temp = PlayerPrefs.GetInt("l" + cord, 0);

        for (byte i = 0; i < missions.Length; i++)
        {
            if ((temp >> i) == 1)
            {
                missions[i].Open = true;
            }
        }
    }
}