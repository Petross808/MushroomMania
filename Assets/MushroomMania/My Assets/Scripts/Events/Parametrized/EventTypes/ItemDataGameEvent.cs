using Items;
using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "ItemDataGameEvent", menuName = "Events/Params/ItemData")]
    public class ItemDataGameEvent : BaseGameEvent<ItemData> { }
}