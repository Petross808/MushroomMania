using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace SelectionSystem
{
    /// <summary>
    /// Any class that implements this interface can be used as a selector for the selection system.
    /// </summary>
    public interface ISelector
    {
        void Check(Ray ray);
        void SelectHovered();
        Transform GetHovered();
        RaycastHit GetHitInfo();
    }
}