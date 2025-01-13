using UnityEngine;
using EventSystem;

namespace SelectionSystem {
    public class BasicSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        private Transform _hovered;
        private Transform _selected;
        private Vector3 _hoveredPosition;

        [SerializeField] private TransformGameEvent _onHoverStartEvent;
        [SerializeField] private Vector3GameEvent _onHoverTickEvent;
        [SerializeField] private TransformGameEvent _onHoverEndEvent;
        [SerializeField] private TransformGameEvent _onSelectEvent;
        [SerializeField] private TransformGameEvent _onDeselectEvent;


        public void OnHoverStart(Transform hoveredTransform)
        {
            _hovered = hoveredTransform;
            _onHoverStartEvent?.Raise(_hovered);
        }

        public void OnHoverTick(Vector3 hoveredPos)
        {
            _hoveredPosition = hoveredPos;
            _onHoverTickEvent?.Raise(_hoveredPosition);
        }

        public void OnHoverEnd()
        {
            _onHoverEndEvent?.Raise(_hovered);
            _hovered = null;
        }

        public void OnSelect()
        {
            if(_selected != null)
            {
                _onDeselectEvent?.Raise(_selected);
            }

            _selected = _hovered;
            _onSelectEvent?.Raise(_selected);
        }
    }
}