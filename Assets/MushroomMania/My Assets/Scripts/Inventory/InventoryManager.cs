using System;
using UnityEngine;

// Modified file from Niall McGuinness' repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

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

            ClearInventories();
        }

        private void OnDestroy()
        {
            ClearInventories();
        }

        /// <summary>
        /// Adds the item to the inventory.
        /// </summary>
        /// <param name="data"></param>
        public void CollectItem(ItemData data)
        {
            _inventoryCollection.Add(data);
        }

        public void ClearInventories()
        {
            _inventoryCollection.ClearInventories();
        }
    }
}