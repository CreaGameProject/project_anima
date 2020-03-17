using UnityEngine;
using System.IO;
using System;

[Serializable]
public class DataSave : MonoBehaviour
{
    //天才か？このクラス
    [Serializable]
    private class WeaponData
    {
        public int[] rifleLevel;
        public int[] shotgunLevel;
    }

    [Serializable]
    private class FixtureData
    {
        public int[] itemNumbers;
        public int[] ingredientNumbers;
    }

    [Serializable]
    private class LevelData
    {
        public bool levelOpen;
        public bool[] missionOpen;
    }

    public static void WeaponSave()
    {
        WeaponData weaponData = new WeaponData();
        weaponData.rifleLevel = new int[Data.Instance.rifles.Length];
        weaponData.shotgunLevel = new int[Data.Instance.shotguns.Length];

        for (int i = 0; i < weaponData.rifleLevel.Length; i++)
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
        fixtureData.ingredientNumbers = new int[Data.Instance.ingredients.Length];

        for (int i = 0; i < fixtureData.itemNumbers.Length; i++)
        {
            fixtureData.itemNumbers[i] = Data.Instance.items[i].Number;
        }
        for (int i = 0; i < fixtureData.ingredientNumbers.Length; i++)
        {
            fixtureData.ingredientNumbers[i] = Data.Instance.ingredients[i].Number;
        }
        SaveMethod("/Data/fixture.json", fixtureData);
    }

    public static void MissionSave()
    {
        for (int i = 0; i < 4; i++)
        {
            LevelData levelData = new LevelData();
            levelData.missionOpen = new bool[Data.Instance.levels[i].missions.Length];

            levelData.levelOpen = Data.Instance.levels[i].Open;
            for (int j = 0; j < levelData.missionOpen.Length; j++)
            {
                levelData.missionOpen[j] = Data.Instance.levels[i].missions[j].Open;
            }
            SaveMethod("/Data/level" + (i + 1).ToString() + ".json", levelData);
        }
    }

    public static void WeaponLoad()
    {
        WeaponData weaponData = new WeaponData();
        LoadMethod("/Data/weapon.json", weaponData);

        for (int i = 0; i < weaponData.rifleLevel.Length; i++)
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
        for (int i = 0; i < fixtureData.ingredientNumbers.Length; i++)
        {
            Data.Instance.ingredients[i].Number = fixtureData.ingredientNumbers[i];
        }
    }

    public static void MissionLoad()
    {
        for (int i = 0; i < 4; i++)
        {
            LevelData levelData = new LevelData();
            LoadMethod("/Data/level" + (i + 1).ToString() + ".json", levelData);

            Data.Instance.levels[i].Open = levelData.levelOpen;
            for (int j = 0; j < levelData.missionOpen.Length; j++)
            {
                Data.Instance.levels[i].missions[j].Open = levelData.missionOpen[j];
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

