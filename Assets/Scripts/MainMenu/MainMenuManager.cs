using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] Button[] _mainBtn;
    [SerializeField] GameObject[] _mainPanel;

    [Header("Settings")]
    public Text _title;
    public string[] _stringTitle = new string[] { "Credits", "Settings" };
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _bgmSlider, _sfxSlider;
    [SerializeField] GameObject _panelSettings;
    [SerializeField] Button _closeBtn;
    [SerializeField] float _multiplier = 45f;
    public bool isPanelSettingsOn;
    private void Awake()
    {
        GetValue();
    }


    private void PanelGetClose()
    {
        _panelSettings.SetActive(false);
        SaveData.SetSetting("Bgm", _bgmSlider.value);
        SaveData.SetSetting("Sfx", _sfxSlider.value);
    }

    private void GetValue()
    {
        if (_panelSettings.active == true) isPanelSettingsOn = true;

        _bgmSlider.value = SaveData.GetSettings("Bgm");
        _sfxSlider.value = SaveData.GetSettings("Sfx");
        _bgmSlider.onValueChanged.AddListener(SetBGMValue);
        _sfxSlider.onValueChanged.AddListener(SetSFXValue);
        
        _closeBtn.onClick.AddListener(PanelGetClose);
        _panelSettings = GameObject.Find("SettingsPanel");

    }

    private void SetBGMValue(float value) => _mixer.SetFloat("BGM_Volume", Mathf.Log10(value) * _multiplier);

    private void SetSFXValue(float value) => _mixer.SetFloat("SFX_Volume", Mathf.Log10(value) * _multiplier);

}
