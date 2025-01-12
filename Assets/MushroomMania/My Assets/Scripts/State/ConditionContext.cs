using UnityEngine;

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