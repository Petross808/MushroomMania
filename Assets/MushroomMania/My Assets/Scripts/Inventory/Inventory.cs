using EventSystem;
using Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

// Modified file from Niall McGuinness' repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace Items
{
    /// <summary>
    /// Stores the amount of each object of type ItemData in the inventory.
    /// Think of an inventory like a pocket in a larger bag (or InventoryCollection).
    /// </summary>
    /// <see cref="ItemData"/>
    /// <see cref="InventoryCollection"/>
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory")]
    public class Inventory : ScriptableGameObject, IEnumerable<ItemAmount>
    {
        [SerializeField]
        [Tooltip("The items in the inventory and their counts.")]
        private List<ItemAmount> _contents = new();

        [SerializeField]
        [Tooltip("Event to raise when the inventory changes.")]
        private GameEvent _onInventoryChange;

        [SerializeField]
        [Tooltip("Event to raise when the inventory is cleared.")]
        private GameEvent _onInventoryClear;

        public int this[ItemData itemData]
        {
            get => GetItem(itemData)?.Amount ?? 0;
        }

        private ItemAmount GetItem(ItemData itemData)
        {
            return _contents.FirstOrDefault(e => e.Item == itemData);
        }


        /// <summary>
        /// Adds the specified amount of items to the inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        public void Add(ItemData item, int count)
        {
            if (count < 1)
                return;

            ItemAmount itemAmount = GetItem(item);

            if(itemAmount != null)
            {
                itemAmount.Amount += count;
            }
            else
            {
                _contents.Add(new() { Item = item, Amount = count });
            }

            RaiseOnChange(); //tell interested parties that the inventory has changed
        }

        /// <summary>
        /// Removes the specified amount of items from the inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Remove(ItemData item, int count)
        {

            ItemAmount itemAmount = GetItem(item);

            if (itemAmount == null) return 0;

            if (itemAmount.Amount > count)
            {
                itemAmount.Amount -= count;
                RaiseOnChange();
                return itemAmount.Amount;
            }

            _contents.Remove(itemAmount);
            RaiseOnChange();
            return 0;

        }

        /// <summary>
        /// Gets the count of the specified item in the inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Count(ItemData item)
        {
            return this[item];
        }

        /// <summary>
        /// Returns true if the inventory contains the specified item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ItemData item)
        {
            return GetItem(item) != null;
        }

        /// <summary>
        /// Removes all items from the inventory.
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            _contents.Clear();
            _onInventoryClear?.Raise();
            RaiseOnChange();
            return _contents.Count == 0;
        }

        [ContextMenu("Raise OnChange")]
        public void RaiseOnChange()
        {
            _onInventoryChange?.Raise();
        }


        public IEnumerator<ItemAmount> GetEnumerator()
        {
            return _contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [Serializable]
    public class ItemAmount
    {
        public ItemData Item;
        public int Amount;
    }
}