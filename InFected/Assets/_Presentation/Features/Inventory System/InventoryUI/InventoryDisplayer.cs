using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryDisplayer : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Inventory inventory;

        [Header("UI Elements")]
        [SerializeField] private InventoryUISlot UISlotPrefab;
        [SerializeField] private Transform Content;

        private List<InventoryUISlotReference> _slots = new();

        private void OnEnable()
        {
            inventory.OnItemAdded += AddSlot;
            inventory.OnItemCountChanged += ChangeSlotCount;
        }

        private void OnDisable()
        {
            inventory.OnItemAdded -= AddSlot;
            inventory.OnItemCountChanged -= ChangeSlotCount;
        }

        private void AddSlot(ItemDataSO item)
        {
            InventoryUISlot slot = Instantiate(UISlotPrefab, Content);
            slot.SetupSlot(item.Icon, item.Name);
            InventoryUISlotReference slotReference = new(slot, item);
            _slots.Add(slotReference);
        }

        private void ChangeSlotCount(ItemDataSO item)
        {
            InventoryUISlot slot = FindSlot(item);

            if (slot != null)
            {
                int count = inventory.GetItemCount(item);

                slot.UpdateSlot(count);
            }
        }

        private InventoryUISlot FindSlot(ItemDataSO item)
        {
            InventoryUISlotReference slotReference = _slots.Find(slot => slot.Item == item);

            if (slotReference != null)
            {
                return slotReference.Slot;
            }

            return null;
        }

        private class InventoryUISlotReference
        {
            public readonly InventoryUISlot Slot;
            public readonly ItemDataSO Item;

            public InventoryUISlotReference(InventoryUISlot slot, ItemDataSO item)
            {
                Slot = slot;
                Item = item;
            }
        }
    }
}
