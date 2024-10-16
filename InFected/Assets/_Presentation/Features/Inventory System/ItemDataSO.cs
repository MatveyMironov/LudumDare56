using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item Data")]
    public class ItemDataSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public bool Stackable { get; private set; }
    }
}
