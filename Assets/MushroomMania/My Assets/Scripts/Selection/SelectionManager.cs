using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace SelectionSystem
{
    /// <summary>
    /// Allows us to attach multiple responses to a selected object
    /// </summary>
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private IRayProvider _rayProvider;
        [SerializeField] private ISelector _selector;
        [SerializeField] private ISelectionResponse _response;

        private Transform _oldHovered;

        private void FixedUpdate()
        {
            _selector.Check(_rayProvider.CreateRay());

            if(_selector.GetHovered() != _oldHovered)
            {
                _response.OnHoverEnd();
                _oldHovered = _selector.GetHovered();

                if(_oldHovered != null)
                    _response.OnHoverStart(_oldHovered);
            }
            else if(_oldHovered != null)
            {
                _response.OnHoverTick();
            }
        }

        public void TrySelect()
        {
            if(_oldHovered != null)
                _selector.SelectHovered();
        }
    }
}