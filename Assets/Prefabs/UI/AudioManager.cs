using UnityEngine;
using UnityEngine.Audio;

public static class AudioManager
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;

    public static void SetVolume(AudioMixer mixer, string exposedParam, float value)
    {
        float clampedValue = Mathf.Clamp(value, 0.0001f, 1f);
        float logValue = Mathf.Log10(clampedValue) * 20;
        mixer.SetFloat(exposedParam, logValue);
        Debug.Log($"Изменено значение громкости '{exposedParam}' на {logValue:F2} dB (слайдер: {clampedValue})");
    }
}