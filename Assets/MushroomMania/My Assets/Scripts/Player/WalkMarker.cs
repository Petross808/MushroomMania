using EventSystem;
using System.Collections;
using UnityEngine;

public class WalkMarker : MonoBehaviour
{
    [SerializeField] private Vector3GameEvent _walkCommand;
    [SerializeField] private GameObject _marker;
    
    private bool _leftClickDown;

    private bool _disabled;

    public void LeftClickPressed()
    {
        _leftClickDown = true;
        WalkCommand();
    }

    public void LeftClickReleased()
    {
        _leftClickDown = false;
    }

    public void Show()
    {
        _marker.SetActive(true);
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        _marker.transform.position = newPosition;

        if(_leftClickDown)
        {
            WalkCommand();
        }
    }

    public void Hide()
    {
        _marker.SetActive(false);
    }

    private void WalkCommand()
    {
        if (!_marker.activeSelf)
            return;

        if (_disabled)
            return;

        _walkCommand?.Raise(_marker.transform.position);
    }

    public void SetDisabled(bool disabled)
    {
        _disabled = disabled;
    }

}
