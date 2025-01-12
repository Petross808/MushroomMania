using System;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

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
        /// <summary>
        /// Items that restore health, provide armor, or give temporary boosts.
        /// </summary>
        Consumable,

        /// <summary>
        /// Decorative or collectible items that enhance the game environment or act as achievements.
        /// </summary>
        Decorative,

        /// <summary>
        /// Items that can be deployed or used in the environment for strategic purposes.
        /// </summary>
        Deployable,

        /// <summary>
        /// Items that can be equipped by the player, like weapons or armor.
        /// </summary>
        Equippable,

        /// <summary>
        /// Items that can be interacted with to perform actions or affect the game environment.
        /// </summary>
        Interactable,

        /// <summary>
        /// Items that provide information, lore, or serve as blueprints.
        /// </summary>
        Informative,

        /// <summary>
        /// Items used to unlock or solve puzzles or progress the storyline.
        /// </summary>
        PuzzleItem,

        /// <summary>
        /// Items that serve as key resources, such as food, water, building materials, or power.
        /// </summary>
        Resource,

        /// <summary>
        /// Weapons used for attacking or defending.
        /// </summary>
        Weapon,

        /// <summary>
        /// Items that are used for navigation or wayfinding.
        /// </summary>
        Waypoint
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
        // Consumable Types
        /// <summary>
        /// Represents an armor vest providing additional protection.
        /// </summary>
        Armor,

        /// <summary>
        /// Represents a health item used to restore player health.
        /// </summary>
        HealthPack,

        /// <summary>
        /// Represents a medkit or similar item that provides a large health boost.
        /// </summary>
        Medkit,

        /// <summary>
        /// Represents a consumable item that provides temporary boosts like increased speed or strength.
        /// </summary>
        PowerUp,

        // Decorative Types
        /// <summary>
        /// Represents a collectible item that can serve as an achievement or reward.
        /// </summary>
        Collectible,

        /// <summary>
        /// Represents a decorative item such as a plant or statue.
        /// </summary>
        DecorativeItem,

        // Deployable Types
        /// <summary>
        /// Represents a throwable tactical item such as a flashbang or smoke grenade.
        /// </summary>
        TacticalItem,

        /// <summary>
        /// Represents a trap or mine that can be deployed for tactical advantage.
        /// </summary>
        Trap,

        /// <summary>
        /// Represents a deployable object such as a turret or barricade.
        /// </summary>
        Turret,

        // Equippable Types
        /// <summary>
        /// Represents a piece of armor that can be equipped by the player.
        /// </summary>
        EquippableArmor,

        /// <summary>
        /// Represents a firearm weapon that can be equipped.
        /// </summary>
        EquippableFirearm,

        /// <summary>
        /// Represents a melee weapon such as a knife or crowbar that can be equipped.
        /// </summary>
        EquippableMeleeWeapon,

        // Informative Types
        /// <summary>
        /// Represents a blueprint or recipe used to create or upgrade an item.
        /// </summary>
        Blueprint,

        /// <summary>
        /// Represents a clue or hint used to assist in solving puzzles.
        /// </summary>
        Clue,

        /// <summary>
        /// Represents a note or document providing lore or game information.
        /// </summary>
        Document,

        // Interactable Types
        /// <summary>
        /// Represents a door that can be opened or closed by the player.
        /// </summary>
        Door,

        /// <summary>
        /// Represents a lever or button that can be activated to trigger mechanisms.
        /// </summary>
        Lever,

        /// <summary>
        /// Represents a switch that changes the state of something in the game environment.
        /// </summary>
        Switch,

        // Puzzle Item Types
        /// <summary>
        /// Represents an artifact or object used to activate or solve puzzles.
        /// </summary>
        Artifact,

        /// <summary>
        /// Represents a key or access card used to unlock doors or access restricted areas.
        /// </summary>
        Key,

        /// <summary>
        /// Represents a puzzle piece that is part of a larger puzzle.
        /// </summary>
        PuzzlePiece,

        // Resource Types
        /// <summary>
        /// Represents a building material such as wood or steel used for construction.
        /// </summary>
        BuildingMaterial,

        /// <summary>
        /// Represents a crafting component that can be used to create or upgrade items.
        /// </summary>
        CraftingComponent,

        /// <summary>
        /// Represents a general resource such as food, water, or fuel.
        /// </summary>
        Resource,

        // Weapon Types
        /// <summary>
        /// Represents ammunition used for reloading firearms.
        /// </summary>
        Ammo,

        /// <summary>
        /// Represents a firearm weapon such as a pistol, rifle, or shotgun.
        /// </summary>
        Firearm,

        /// <summary>
        /// Represents a melee weapon such as a knife or crowbar.
        /// </summary>
        MeleeWeapon,

        /// <summary>
        /// Represents a special weapon such as a rocket launcher or sniper rifle.
        /// </summary>
        SpecialWeapon
    }
}