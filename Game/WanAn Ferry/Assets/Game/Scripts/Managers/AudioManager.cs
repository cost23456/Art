using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : Singleton<AudioManager>
{
    public AudioMixer AudioMixer;
    //public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider FXSlider;

    private const string BGM_VOLUME_KEY = "BGM";
    private const string FX_VOLUME_KEY = "FX";
    //private const string Master_VOLUME_KEY = "Master";
    private void Start()
    {
        // ³õÊ¼»¯»¬¿é£¬¶ÁÈ¡´æµµ
        float bgmValue = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f);
        float fxValue = PlayerPrefs.GetFloat(FX_VOLUME_KEY, 1f);
        //float masterValue = PlayerPrefs.GetFloat(Master_VOLUME_KEY, 1f);

        //this.MasterSlider.value = masterValue;
        this.BGMSlider.value = bgmValue;
        this.FXSlider.value = fxValue;

        //this.SetMasterVolume(masterValue);
        this.SetBGMVolume(bgmValue);
        this.SetFXVolume(fxValue);

        // °ó¶¨»¬¿éÊÂ¼þ
        this.BGMSlider.onValueChanged.AddListener(SetBGMVolume);
        this.FXSlider.onValueChanged.AddListener(SetFXVolume);
        //this.MasterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    //public void SetMasterVolume(float value)
    //{
    //    float clampedValue = Mathf.Max(value, 0.0001f);
    //    float db = Mathf.Log10(clampedValue) * 20f;
    //    AudioMixer.SetFloat(Master_VOLUME_KEY, db);
    //    PlayerPrefs.SetFloat(BGM_VOLUME_KEY, value);
    //}
    public void SetBGMVolume(float value)
    {
        // ±ÜÃâlog10(0)±¨´í
        float clampedValue = Mathf.Max(value, 0.0001f);
        float db = Mathf.Log10(clampedValue) * 20f;
        AudioMixer.SetFloat(BGM_VOLUME_KEY, db);
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, value);
    }

    public void SetFXVolume(float value)
    {
        float clampedValue = Mathf.Max(value, 0.0001f);
        float db = Mathf.Log10(clampedValue) * 20f;
        AudioMixer.SetFloat(FX_VOLUME_KEY, db);
        PlayerPrefs.SetFloat(FX_VOLUME_KEY, value);
    }
}