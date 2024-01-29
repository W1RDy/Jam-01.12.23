using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public DataContainer container;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadData();
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void SaveData()
    {
        foreach (var field in typeof(DataContainer).GetFields())
        {
            PlayerPrefs.SetString(field.Name, (string)field.GetValue(container));
        }
    }

    public void LoadData()
    {
        foreach (var field in typeof(DataContainer).GetFields())
        {
            var _value = PlayerPrefs.GetString(field.Name);
            if (_value != "") field.SetValue(container, _value);
        }
    }
}

[Serializable]
public class DataContainer
{
    public string _availableLevelIndex = "0";
}
