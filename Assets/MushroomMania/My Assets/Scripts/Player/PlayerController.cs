using EventSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;

    [SerializeField] private GameEvent _leftClickEvent;
    [SerializeField] private GameEvent _rightClickEvent;
    [SerializeField] private GameEvent _leftClickReleasedEvent;
    [SerializeField] private GameEvent _rightClickReleasedEvent;
    [SerializeField] private Vector2GameEvent _positionMouseEvent;
    [SerializeField] private Vector2GameEvent _deltaMouseEvent;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _input.actions["LeftClick"].started += LeftClick;
        _input.actions["LeftClick"].canceled += LeftClickEnd;
        _input.actions["RightClick"].started += RightClick;
        _input.actions["RightClick"].canceled += RightClickEnd;
        _input.actions["MousePosition"].performed += PositionMouse;
        _input.actions["MouseDelta"].performed += DeltaMouse;
    }

    private void OnDisable()
    {
        _input.actions["LeftClick"].started -= LeftClick;
        _input.actions["LeftClick"].canceled -= LeftClickEnd;
        _input.actions["RightClick"].started -= RightClick;
        _input.actions["RightClick"].canceled -= RightClickEnd;
        _input.actions["MousePosition"].performed -= PositionMouse;
        _input.actions["MouseDelta"].performed -= DeltaMouse;
    }

    private void LeftClick(InputAction.CallbackContext context)
    {
        _leftClickEvent?.Raise();
    }

    private void RightClick(InputAction.CallbackContext context)
    {
        _rightClickEvent?.Raise();
    }

    private void LeftClickEnd(InputAction.CallbackContext context)
    {
        _leftClickReleasedEvent?.Raise();
    }

    private void RightClickEnd(InputAction.CallbackContext context)
    {
        _rightClickReleasedEvent?.Raise();
    }

    private void PositionMouse(InputAction.CallbackContext context)
    {
        _positionMouseEvent?.Raise(context.ReadValue<Vector2>());
    }

    private void DeltaMouse(InputAction.CallbackContext context)
    {
        _deltaMouseEvent?.Raise(context.ReadValue<Vector2>());
    }
}
