using UnityEngine;
using System;
using System.Collections.Generic;


public class Data : MonoBehaviour
{
    public static Data Instance;

    public static Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>();
    public Weapon[] weapons;

    public static Dictionary<string, Item> Items = new Dictionary<string, Item>();
    public Item[] items;
    public Weapon MainWeapon;
    public Weapon SubWeapon;
    public Mission selectedMission;
    public Item[] takeItems;

    public static Dictionary<string, Material> Materials = new Dictionary<string, Material>();
    public Material[] materials;

    public Level[] levels;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        for (int i = 0; i < weapons.Length; i++)
        {
            if (!Weapons.ContainsKey(weapons[i].name))
            {
                Weapons.Add(weapons[i].name, weapons[i]);
            }
        }
        for (int i = 0; i < items.Length; i++)
        {
            if (!Items.ContainsKey(items[i].name))
            {
                Items.Add(items[i].name, items[i]);
            }
        }
        for (int i = 0; i < materials.Length; i++)
        {
            if (!Materials.ContainsKey(materials[i].name))
            {
                Materials.Add(materials[i].name, materials[i]);
            }
        }
    }
}

[Serializable]
public class Level
{
    [SerializeField] private bool open;
    [HideInInspector] public bool[] missionOpen;
    public Mission[] missions;

    public bool Open { get { return open; } set { open = value; } }
}