using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace SelectionSystem
{
    /// <summary>
    /// Allows us to attach multiple responses to a selected object
    /// </summary>
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider _rayProvider;
        private ISelector _selector;
        private ISelectionResponse _response;
        private Transform _oldHovered;

        private void Awake()
        {
            _rayProvider = GetComponent<IRayProvider>();
            _selector = GetComponent<ISelector>();
            _response = GetComponent<ISelectionResponse>();

            if(_rayProvider == null || _selector == null || _response == null)
            {
                throw new System.Exception("Selection System not set up properly");
            }
        }

        private void FixedUpdate()
        {
            _selector.Check(_rayProvider.CreateRay());

            if(_selector.GetHovered() != _oldHovered)
            {
                _response.OnHoverEnd();
                _oldHovered = _selector.GetHovered();

                if(_oldHovered != null)
                {
                    _response.OnHoverStart(_oldHovered);
                    _response.OnHoverTick(_selector.GetHitInfo().point);
                }
            }
            else if(_oldHovered != null)
            {
                _response.OnHoverTick(_selector.GetHitInfo().point);
            }
        }

        public void TrySelect()
        {
            if (_oldHovered != null)
            {
                _response.OnSelect();
            }
        }
    }
}