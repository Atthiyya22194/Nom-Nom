using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public static void SetPlayerProgress(string key, float value) => PlayerPrefs.SetFloat(key, value);

    public static float GetPlayerProgress(string key) => PlayerPrefs.GetFloat(key);

    public static void SetSetting(string key, float value) => PlayerPrefs.SetFloat(key, value);

    public static float GetSettings(string key) => PlayerPrefs.GetFloat(key);
}
