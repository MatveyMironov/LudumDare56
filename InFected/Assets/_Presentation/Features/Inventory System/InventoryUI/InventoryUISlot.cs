using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryUISlot : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemCount;

        public void SetupSlot(Sprite icon, string name)
        {
            itemIcon.sprite = icon;
            itemName.text = name;
        }

        public void UpdateSlot(int count)
        {
            itemCount.text = count.ToString();
        }
    }
}
