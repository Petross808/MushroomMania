using UnityEngine;

public class MouseRotationScript : MonoBehaviour
{
    [SerializeField] private Vector2 _sensitivity;
    [SerializeField, Range(-90, 90)] private int _minVerticalAngle = -80;
    [SerializeField, Range(-90, 90)] private int _maxVerticalAngle = 80;

    private bool _rightClickDown;

    public void RightClickPressed()
    {
        _rightClickDown = true;
    }

    public void RightClickReleased()
    {
        _rightClickDown = false;
    }

    public void MouseChanged(Vector2 delta)
    {
        if (!_rightClickDown)
            return;

        Vector3 rotationEuler = transform.rotation.eulerAngles;
        Vector3 newRotation = Vector3.zero;

        //Convert from (90 to 0/360 to 270) range to (90 to 0 to -90) range, add the delta and clamp to (-80, 80)
        newRotation.x = Mathf.Clamp((-Mathf.DeltaAngle(rotationEuler.x, 0) - (delta.y * _sensitivity.y)), _minVerticalAngle, _maxVerticalAngle);
        newRotation.y = (rotationEuler.y + (delta.x * _sensitivity.x));
        newRotation.z = 0;

        transform.rotation = Quaternion.Euler(newRotation);
    }
}