using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "TransformGameEvent", menuName = "Events/Params/Transform")]
    public class TransformGameEvent : BaseGameEvent<Transform> { }
}