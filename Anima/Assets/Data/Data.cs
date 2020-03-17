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

    public Ingredient[] ingredients;

    public Level[] levels;
    public ImportantMission[] importants;

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
    public bool Open { get { return open; } set { open = value; } }

    public Mission[] missions;
}