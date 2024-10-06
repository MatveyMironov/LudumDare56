using UnityEngine;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "NewAudioSettings", menuName = "Audio/Audio Settings Data")]
    public class AudioSettingsDataSO : ScriptableObject
    {
        public float masterVolume;
        public float effectsVolume;
        public float voiceVolume;
        public float musicVolume;
    }
}
