using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private const string MusicPref = "MusicVolume";
    private const string SfxPref = "SFXVolume";

    private void Awake()
    {
        if (_audioMixer == null || _musicSlider == null || _sfxSlider == null)
        {
            Debug.LogError("Не назначены ссылки в AudioSettingsUI!");
            return;
        }

        float savedMusicVolume = PlayerPrefs.GetFloat(MusicPref, 1.0f);
        float savedSfxVolume = PlayerPrefs.GetFloat(SfxPref, 1.0f);

        _musicSlider.SetValueWithoutNotify(savedMusicVolume);
        _sfxSlider.SetValueWithoutNotify(savedSfxVolume);

        SetMusicVolume(savedMusicVolume);
        SetSFXVolume(savedSfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.SetVolume(_audioMixer, "Music", volume);
        PlayerPrefs.SetFloat(MusicPref, volume);
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.SetVolume(_audioMixer, "SFX", volume);
        PlayerPrefs.SetFloat(SfxPref, volume);
    }
}