using EventSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameEvent _onPlayState;
    [SerializeField] GameEvent _onMenuState;
    [SerializeField] GameEvent _onGameStateTransition;

    private void Awake()
    {
        this.EnsureSingleInstance();
    }

    private void Start()
    {
        OpenMainMenu();
    }

    public void PlayGame()
    {
        _onGameStateTransition.Raise();
        _onPlayState.Raise();
    }

    public void OpenMainMenu()
    {
        _onGameStateTransition.Raise();
        _onMenuState.Raise();
    }
}
