using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem
{
    public class MouseRayProvider : MonoBehaviour, IRayProvider
    {
        private Vector2 _mousePosition;

        public Ray CreateRay()
        {
            return Camera.main.ScreenPointToRay(_mousePosition);
        }

        public void OnUpdateMousePosition(Vector2 mousePosition)
        {
            _mousePosition = mousePosition;
        }
    }
}
