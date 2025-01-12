using UnityEngine;

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