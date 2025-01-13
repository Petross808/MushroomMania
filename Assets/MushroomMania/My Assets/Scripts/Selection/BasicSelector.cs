using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem
{
    public class BasicSelector : MonoBehaviour, ISelector
    {
        [SerializeField, Min(0)] private int _maxDistance;
        [SerializeField] private LayerMask _layerMask;

        private RaycastHit _hitInfo;
        private bool _hit;

        public void Check(Ray ray)
        {
            _hit = Physics.Raycast(ray, out _hitInfo, _maxDistance, _layerMask);
        }

        public RaycastHit GetHitInfo()
        {
            return _hitInfo;
        }

        public Transform GetHovered()
        {
            return _hit ? _hitInfo.transform : null;
        }
    }
}
