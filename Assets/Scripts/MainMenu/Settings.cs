using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Text _title;
    public string[] _stringTitle = new string[] { "Settings", "Credits" };
    
    [Header("Settings")]
    [SerializeField] Slider _bgmSlider, _sfxSlider;
    [SerializeField] AudioMixer _mixer;
    [SerializeField] float _multiplier = 45f;

    private void Awake()
    {
        GetSlider();
    }

    private void GetSlider()
    {
        _bgmSlider.value = SaveData.GetSettings("Bgm");
        _bgmSlider.onValueChanged.AddListener(SetSliderValue);
        _mixer.SetFloat("BGM_Volume", _bgmSlider.value);

    }

    private void SetSliderValue(float value)
    {
        _mixer.SetFloat("BGM_Volume", Mathf.Log10(value)*_multiplier);
    }
}
