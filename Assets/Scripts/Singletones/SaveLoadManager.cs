using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public int currentLevel;
    public int currentRetries;

    public event Action OnDataChanged;
    
    private void Start()
    {
        LoadFromJson();
        Debug.Log(currentLevel.ToString() + ", " + currentRetries.ToString());
    }

    public void SaveToJson()
    {
        PlayerData playerData = new PlayerData
        {
            LevelCount = currentLevel,
            RetriesCount = currentRetries
        };

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
    }

    public void LoadFromJson()
    {
        if (File.Exists(Application.dataPath + "/PlayerData.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/PlayerData.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            currentLevel = playerData.LevelCount;
            currentRetries = playerData.RetriesCount;
            OnDataChanged?.Invoke();
            Debug.Log("Save file loaded successfully");
        }
        else
        {
            Debug.Log("No save file");
        }
    }
}

public class PlayerData
{
    public int LevelCount;
    public int RetriesCount;
}
