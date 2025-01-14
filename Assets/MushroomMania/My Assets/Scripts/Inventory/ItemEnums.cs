using System;

// Modified file from Niall McGuinness' repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace Items
{
    /// <summary>
    /// Defines the various high-level categories of items available in a game.
    /// Each category groups similar item types under one classification.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    /// <see cref="GD.Inventory"/>
    [Serializable]
    public enum ItemCategoryType
    {
        Mushroom
    }

    /// <summary>
    /// Defines the various specific types of items available in a game.
    /// These types are grouped under the broader categories represented by ItemCategoryType.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    /// <see cref="GD.Inventory"/>
    [Serializable]
    public enum ItemType
    {
        Edible,
        Poisonous
    }
}