using UnityEngine;

// Modified file from Niall McGuinness' repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace State
{
    /// <summary>
    /// Store reference to entities/objects that the conditions need to check against.
    /// </summary>
    public class ConditionContext
    {
        public GameObject GameObject { get; set; }

        // Add other context dependencies here

        public ConditionContext(GameObject gameObject = null)
        {
            GameObject = gameObject;
        }
    }
}