using UnityEngine;
using UnityEngine.UI;

namespace AudioSystem
{
    public class AudioSettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioSettingsDataSO audioSettingsData;

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider effectsSlider;
        [SerializeField] private Slider musicSlider;

        [Space]
        [SerializeField] private AudioSettings audioSettings;

        private void Awake()
        {
            masterSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("MasterVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.masterVolume));
            effectsSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("EffectsVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.effectsVolume));
            musicSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("MusicVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.musicVolume));
        }
    }
}
