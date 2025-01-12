using UnityEngine;

namespace SelectionSystem
{
    /// <summary>
    /// Any class that implements this interface can respond to selection and deselection events.
    /// </summary>
    public interface ISelectionResponse
    {
        void OnHoverStart(Transform hoveredTransform);
        void OnHoverTick();
        void OnHoverEnd();
        void OnSelect();
    }
}