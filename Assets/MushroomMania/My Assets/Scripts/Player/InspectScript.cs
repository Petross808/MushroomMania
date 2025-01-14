using UnityEngine;

public class InspectScript : MonoBehaviour
{

    [SerializeField] private Transform _pivot;
    [SerializeField] private Vector3 _offset;

    private Vector3 _originalPosition;
    private Transform _inspecting;

    public void InspectTransform(Transform toInspect)
    {
        _inspecting = toInspect;
        _originalPosition = _inspecting.position;
        _inspecting.position = _pivot.position + _offset;
    }

    public void StopInspect()
    {
        if(_inspecting == null) return;

        _inspecting.position = _originalPosition;
        _inspecting = null;
        _originalPosition = Vector3.zero;
    }
}
