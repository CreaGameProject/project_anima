using UnityEngine;
using System;
using System.Collections.Generic;


public class Data : MonoBehaviour
{
    public static Data Instance;

    public Weapon[] rifles;
    public Weapon[] shotguns;

    public Item[] items;

    public Weapon MainWeapon;
    //public Weapon SubWeapon;
    public Mission selectedMission;
    public Item[] takeItems;

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