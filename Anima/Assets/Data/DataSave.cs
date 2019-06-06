using UnityEngine;
using System.IO;
using System;

[Serializable]
public class DataSave : MonoBehaviour
{
    public static void WeaponSave()
    {
        foreach (Weapon weapon in Data.Instance.weapons)
        {
            SaveMethod("/Data/Weapons/" + weapon.name + ".json", weapon);
        }
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
        MissionData missions = new MissionData();

        int levelsLength = Data.Instance.levels.Length;
        missions.isOpened = new bool[levelsLength][];

        for(int i = 0; i < levelsLength; i++)
        {
            int missionsLength = Data.Instance.levels[i].missions.Length + 1;
            missions.isOpened[i] = new bool[missionsLength];
            missions.isOpened[i][0] = Data.Instance.levels[i].Open;

            for (int j = 1; j < missionsLength; j++)
            {
                missions.isOpened[i][j] = Data.Instance.levels[i].missions[j - 1].Open;
            }
        }

        SaveMethod("/Data/missions.json", missions);
    }


    public static void WeaponLoad()
    {
        foreach (Weapon weapon in Data.Instance.weapons)
        {
            LoadMethod("/Data/Weapons/" + weapon.name + ".json", weapon);
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
        MissionData missions = new MissionData();

        LoadMethod("/Data/missions.json", missions);

        missions.isOpened = new bool[4,16];
        int levelsLength = missions.isOpened.GetLength(0);

        for (int i = 0; i < levelsLength; i++)
        {
            int missionslength = missions.isOpened.GetLength(1);
            Data.Instance.levels[i].Open = missions.isOpened[i,0];

            for (int j = 1; j < missionslength; j++)
            {
                Data.Instance.levels[i].missions[j - 1].Open = missions.isOpened[i,j];
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
    }
}

[Serializable]
public class MissionData
{
    public bool[,] isOpened;
}

[Serializable]
public class FixtureData
{
    public int[] itemNumbers;
    public int[] materialNumbers;
}
