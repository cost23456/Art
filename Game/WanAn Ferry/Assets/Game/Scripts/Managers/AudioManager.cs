using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource BGM;
    public AudioSource FX;
    public AudioMixer AudioMixer;
    public Slider BGMSlider;
    public Slider FXSlider;
    private const string BGM_VOLUME_KEY = "BGM";
    private const string FX_VOLUME_KEY = "FX";
    private void Start()
    {
        // ³õÊ¼»¯»¬¿é£¬¶ÁÈ¡´æµµ
        float bgmValue = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f);
        float fxValue = PlayerPrefs.GetFloat(FX_VOLUME_KEY, 1f);

        this.BGMSlider.value = bgmValue;
        this.FXSlider.value = fxValue;

        this.SetBGMVolume(bgmValue);
        this.SetFXVolume(fxValue);

        // °ó¶¨»¬¿éÊÂ¼þ
        this.BGMSlider.onValueChanged.AddListener(SetBGMVolume);
        this.FXSlider.onValueChanged.AddListener(SetFXVolume);
    }
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

    public void PlayBGMAudio(AudioClip audioClip)
    {
        this.BGM.clip = audioClip;
        this.BGM.Play();
        this.BGM.loop = true;
    }
    public void PlayFXAudio(AudioClip audioClip)
    {
        this.FX.clip = audioClip;
        this.FX.Play();
        this.FX.loop = false;
    }

}