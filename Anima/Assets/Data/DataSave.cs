using UnityEngine;
using System.IO;
using System;

[Serializable]
public class DataSave : MonoBehaviour
{
    public static void WeaponSave()
    {
        WeaponData weaponData = new WeaponData();
        weaponData.rifleLevel = new int[Data.Instance.rifles.Length];
        weaponData.shotgunLevel = new int[Data.Instance.shotguns.Length];

        for(int i = 0; i < weaponData.rifleLevel.Length; i++)
        {
            weaponData.rifleLevel[i] = Data.Instance.rifles[i].Level;
        }
        for (int i = 0; i < weaponData.shotgunLevel.Length; i++)
        {
            weaponData.rifleLevel[i] = Data.Instance.shotguns[i].Level;
        }
        SaveMethod("/Data/weapon.json", weaponData);
    }

    public static void FixtureSave()
    {
        FixtureData fixtureData = new FixtureData();
        fixtureData.itemNumbers = new int[Data.Instance.items.Length];
        fixtureData.materialNumbers = new int[Data.Instance.materials.Length];

        for(int i = 0; i < fixtureData.itemNumbers.Length; i++)
        {
            fixtureData.itemNumbers[i] = Data.Instance.items[i].Number;
        }
        for(int i = 0; i < fixtureData.materialNumbers.Length; i++)
        {
            fixtureData.materialNumbers[i] = Data.Instance.materials[i].Number;
        }
        SaveMethod("/Data/fixture.json", fixtureData);
    }

    public static void MissionSave()
    {
        for (int i = 0; i < 4; i++)
        {
            Data.Instance.levels[i].missionOpen = new bool[Data.Instance.levels[i].missions.Length];
            for (int j = 0; j < Data.Instance.levels[i].missions.Length; j++)
            {
                Data.Instance.levels[i].missionOpen[j] = Data.Instance.levels[i].missions[j].Open;
            }
            SaveMethod("/Data/level"+(i+1).ToString()+".json", Data.Instance.levels[i]);
        }
    }


    public static void WeaponLoad()
    {
        WeaponData weaponData = new WeaponData();
        LoadMethod("/Data/weapon.json", weaponData);

        for(int i = 0; i < weaponData.rifleLevel.Length; i++)
        {
            Data.Instance.rifles[i].Level = weaponData.rifleLevel[i];
        }
        for (int i = 0; i < weaponData.shotgunLevel.Length; i++)
        {
            Data.Instance.shotguns[i].Level = weaponData.shotgunLevel[i];
        }
    }

    public static void FixtureLoad()
    {
        FixtureData fixtureData = new FixtureData();

        LoadMethod("/Data/fixture.json", fixtureData);

        for (int i = 0; i < fixtureData.itemNumbers.Length; i++)
        {
            Data.Instance.items[i].Number = fixtureData.itemNumbers[i];
        }
        for (int i = 0; i < fixtureData.materialNumbers.Length; i++)
        {
            Data.Instance.materials[i].Number = fixtureData.materialNumbers[i];
        }
    }

    public static void MissionLoad()
    {
        for (int i = 0; i < 4; i++)
        {
            Data.Instance.levels[i].missionOpen = new bool[Data.Instance.levels[i].missions.Length];
            LoadMethod("/Data/level" + (i + 1).ToString() + ".json", Data.Instance.levels[i]);


            for (int j = 0; j < Data.Instance.levels[i].missions.Length; j++)
            {
                Data.Instance.levels[i].missions[j].Open = Data.Instance.levels[i].missionOpen[j];
            }
        }
    }


    public static void SaveMethod(string localPath, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Application.dataPath + localPath;
        var writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    public static void LoadMethod(string localPath, object data)
    {
        var info = new FileInfo(Application.dataPath + localPath);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        JsonUtility.FromJsonOverwrite(json, data);
        reader.Close();
    }
}

[Serializable]
public class FixtureData
{
    public int[] itemNumbers;
    public int[] materialNumbers;
}

[Serializable]
public class WeaponData
{
    public int[] rifleLevel;
    public int[] shotgunLevel;
}
