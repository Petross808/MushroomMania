using System;
using UnityEngine;

namespace Items
{
    /// <summary>
    /// Manages the players inventory, listens for events, etc.
    /// </summary>
    /// <see cref="Inventory"/>
    /// <see cref="ItemData"/>
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The player's inventory collection (e.g. a saddlebag")]
        private InventoryCollection _inventoryCollection;

        private void Awake()
        {
            //check if the inventory collection has been added
            if (_inventoryCollection == null)
                throw new NullReferenceException("No inventory collection has been added");
        }

        /// <summary>
        /// Adds the item to the inventory.
        /// </summary>
        /// <param name="data"></param>
        public void CollectItem(ItemData data)
        {
            _inventoryCollection.Add(data);
        }
    }
}