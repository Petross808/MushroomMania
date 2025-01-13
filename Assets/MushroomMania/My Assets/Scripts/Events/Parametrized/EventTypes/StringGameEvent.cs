using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "StringGameEvent", menuName = "Events/Params/String")]
    public class StringGameEvent : BaseGameEvent<string> { }
}