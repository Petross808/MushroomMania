using Types;
using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace Items
{
    /// <summary>
    /// Stores all data for an item used when the item is consumed or picked up
    /// </summary>
    /// <see cref="Inventory"/>
    /// <see cref="InventoryCollection"/>
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]
    public class ItemData : ScriptableGameObject
    {
        [SerializeField]
        [Tooltip("The category of item")]
        private ItemCategoryType itemCategory = ItemCategoryType.Consumable;

        [SerializeField]
        [Tooltip("The type of item")]
        private ItemType itemType = ItemType.Resource;

        [SerializeField]
        [Tooltip("The sprite that represents this item in the UI")]
        private Sprite uiIcon;

        [SerializeField]
        [Tooltip("The audio clip that represents this item")]
        private AudioClip audioClip;

        [SerializeField]
        [Tooltip("The position of the audio source that plays the audio clip")]
        private Vector3 audioPosition;

        public ItemCategoryType ItemCategory { get => itemCategory; set => itemCategory = value; }
        public ItemType ItemType { get => itemType; set => itemType = value; }

        public Sprite UiIcon { get => uiIcon; set => uiIcon = value; }
        public AudioClip AudioClip { get => audioClip; set => audioClip = value; }
        public Vector3 AudioPosition { get => audioPosition; set => audioPosition = value; }

    }
}