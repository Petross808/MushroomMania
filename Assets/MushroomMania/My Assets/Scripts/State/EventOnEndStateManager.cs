using EventSystem;
using State;
using UnityEngine;

public class EventOnEndStateManager : StateManager
{
    [SerializeField] private GameEvent _onGameWon;
    [SerializeField] private GameEvent _onGameLost;

    protected override void HandleWin()
    {
        _onGameWon?.Raise();
    }

    protected override void HandleLoss()
    {
        _onGameLost?.Raise();
    }
}
