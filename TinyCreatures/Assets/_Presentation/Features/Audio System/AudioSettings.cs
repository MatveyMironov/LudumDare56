using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioSystem
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioSettingsDataSO audioSettingsData;
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private MusicManager musicManager;

        private void Start()
        {
            SetVolume("MasterVolume", audioSettingsData.masterVolume, ref audioSettingsData.masterVolume);
            SetVolume("EffectsVolume", audioSettingsData.effectsVolume, ref audioSettingsData.effectsVolume);
            SetVolume("VoiceVolume", audioSettingsData.voiceVolume, ref audioSettingsData.voiceVolume);
            SetVolume("MusicVolume", audioSettingsData.musicVolume, ref audioSettingsData.musicVolume);
        }

        public void SetVolume(string audioGroupVolume, float volume, ref float volumeData)
        {
            audioMixer.SetFloat(audioGroupVolume, Mathf.Log10(volume) * 20);
            volumeData = volume;
        }
    }
}
