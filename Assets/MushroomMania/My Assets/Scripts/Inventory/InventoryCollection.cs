using EventSystem;
using Types;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Items
{
    //TODO - Fix Add on new ItemCategoryType

    /// <summary>
    /// Stores a dictionary of inventories
    /// </summary>
    /// <see cref="Inventory"/>
    /// <see cref="InventoryManager"/>
    [CreateAssetMenu(fileName = "InventoryCollection", menuName = "Inventory/Collection")]
    public class InventoryCollection : ScriptableGameObject
    {
        [SerializeField]
        [Tooltip("A list of all inventores (e.g. a saddlebag")]
        private List<InventoryCategory> _contents = new();

        [SerializeField]
        [Tooltip("Event to raise when the collection changes.")]
        private GameEvent _onCollectionChange;

        [SerializeField]
        [Tooltip("Event to raise when the collection is emptied.")]
        private GameEvent _onCollectionEmpty;

        public Inventory this[ItemCategoryType categoryType]
        {
            get => GetCategory(categoryType)?.Inventory;
        }

        public Inventory Get(ItemCategoryType itemCategory)
        {
            return this[itemCategory];
        }

        private InventoryCategory GetCategory(ItemCategoryType itemData)
        {
            return _contents.FirstOrDefault(e => e.ItemCategoryType == itemData);
        }

        //add a new inventory to the collection
        public void Add(ItemData itemData)
        {
            var inv = this[itemData.ItemCategory];
            if(inv == null)
                throw new NullReferenceException("No inventory for this item category");

            //add 1 specific consumable (e.g. ItemData = Apple) to the inventory
            inv.Add(itemData, 1);
            //TODO - add more than 1?

            //tell interested parties that the collection has changed
            _onCollectionChange?.Raise();
        }

        /// <summary>
        /// Removes all inventories from the collection.
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            _contents.Clear();
            _onCollectionEmpty?.Raise();
            return _contents.Count == 0;
        }
    }

    [Serializable]
    class InventoryCategory
    {
        public ItemCategoryType ItemCategoryType;
        public Inventory Inventory;
    }
}