using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioSystem
{
    public class AudioSettingsWindow : MonoBehaviour
    {
        [SerializeField] private AudioSettingsDataSO audioSettingsData;
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private MusicManager musicManager;

        [Header("UI Elements")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider effectsSlider;
        [SerializeField] private Slider musicSlider;

        private void Awake()
        {
            masterSlider.onValueChanged.AddListener((float volume) => SetVolume("MasterVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.masterVolume));
            effectsSlider.onValueChanged.AddListener((float volume) => SetVolume("EffectsVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.effectsVolume));
            musicSlider.onValueChanged.AddListener((float volume) => SetVolume("MusicVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.musicVolume));
        }

        private void Start()
        {
            SetVolume("MasterVolume", audioSettingsData.masterVolume, ref audioSettingsData.masterVolume);
            SetVolume("MusicVolume", audioSettingsData.musicVolume, ref audioSettingsData.musicVolume);
            SetVolume("EffectsVolume", audioSettingsData.effectsVolume, ref audioSettingsData.effectsVolume);

        }

        private void SetVolume(
            string audioGroupVolume,
            float volume,
            ref float volumeData)
        {
            audioMixer.SetFloat(audioGroupVolume, Mathf.Log10(volume) * 20);
            volumeData = volume;
        }
    }
}
