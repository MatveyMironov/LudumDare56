using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] Dictionary<ItemDataSO, int> items = new();

        public Action<ItemDataSO> OnItemCountChanged;

        public void AddItem(ItemDataSO item, int count = 1)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Inventory can't store negative amount of items");
            }

            if (items.ContainsKey(item))
            {
                items[item] += count;
            }
            else
            {
                items.Add(item, count);
            }

            OnItemCountChanged?.Invoke(item);
        }

        public void RemoveItem(ItemDataSO item, int count = 1)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Can,t remove negative amount of items");
            }

            if (items.ContainsKey(item))
            {
                if (items[item] < count)
                {
                    throw new ArgumentOutOfRangeException("Can't remove from inventory more items than is currently stored");
                }

                items[item] -= count;
            }

            OnItemCountChanged?.Invoke(item);
        }

        public int GetItemCount(ItemDataSO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (items.ContainsKey(item))
            {
                return items[item];
            }
            else
            {
                return 0;
            }
        }
    }
}