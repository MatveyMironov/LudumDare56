using Pause;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AudioSystem
{
    public class AudioSettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioSettingsDataSO audioSettingsData;

        [Space]
        [SerializeField] private GameObject menuObject;

        [Space]
        [SerializeField] private Button closeButton;
        [SerializeField] private MainPauseMenu mainPauseMenu;

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider effectsSlider;
        [SerializeField] private Slider voiceSlider;
        [SerializeField] private Slider musicSlider;

        [Space]
        [SerializeField] private AudioSettings audioSettings;

        private bool _isOpened;

        private void Awake()
        {
            closeButton.onClick.AddListener(CloseMenu);
            closeButton.onClick.AddListener(mainPauseMenu.OpenMenu);

            masterSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("MasterVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.masterVolume));
            effectsSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("EffectsVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.effectsVolume));
            effectsSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("VoiceVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.voiceVolume));
            musicSlider.onValueChanged.AddListener((float volume) => audioSettings.SetVolume("MusicVolume", Mathf.Clamp(volume, 0.001f, float.MaxValue), ref audioSettingsData.musicVolume));
        }

        public void OpenMenu()
        {
            if (_isOpened) { return; }

            menuObject.SetActive(true);

            _isOpened = true;
        }

        public void CloseMenu()
        {
            if (!_isOpened) { return; }

            menuObject.SetActive(false);

            _isOpened = false;
        }
    }
}
