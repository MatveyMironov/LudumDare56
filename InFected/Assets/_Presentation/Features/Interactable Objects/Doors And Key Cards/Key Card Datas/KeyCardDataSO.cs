using InventorySystem;
using UnityEngine;

namespace Door
{
    [CreateAssetMenu(fileName = "NewKeyCardData", menuName = "Items/Key Card")]
    public class KeyCardDataSO : ItemDataSO
    {
        [field: SerializeField] public Color Color { get; private set; }
    }
}
