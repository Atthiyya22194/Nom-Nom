using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public static void SetPlayerProgress(string key, float value) => PlayerPrefs.SetFloat(key, value);

    public static float GetPlayerProgress(string key) => PlayerPrefs.GetFloat(key);

    public static void SetSetting(string key, int value) => PlayerPrefs.SetInt(key, value);

    public static int GetSettings(string key) => PlayerPrefs.GetInt(key);
}
