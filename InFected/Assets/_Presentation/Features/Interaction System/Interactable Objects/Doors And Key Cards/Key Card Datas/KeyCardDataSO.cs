using UnityEngine;

namespace Door
{
    [CreateAssetMenu(fileName = "NewKeyCardData", menuName = "Key Card Data")]
    public class KeyCardDataSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}
