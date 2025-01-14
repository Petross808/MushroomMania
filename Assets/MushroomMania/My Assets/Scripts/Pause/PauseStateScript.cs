using EventSystem;
using UnityEngine;

public class PauseStateScript : MonoBehaviour
{
    [SerializeField] private bool _isPaused;
    [SerializeField] private BoolGameEvent _onPauseStateChangedEvent;

    private void Awake()
    {
        this.EnsureSingleInstance();
    }

    private void Start()
    {
        _onPauseStateChangedEvent?.Raise(_isPaused);
    }

    public void SetPause(bool pauseState)
    {
        if (pauseState)
            PauseGame();
        else
            ResumeGame();
    }

    public void PauseGame()
    {
        if (_isPaused)
            return;

        _isPaused = true;
        Time.timeScale = 0f;
        _onPauseStateChangedEvent?.Raise(true);
    }

    public void ResumeGame()
    {
        if (!_isPaused)
            return;

        _isPaused = false;
        Time.timeScale = 1f;
        _onPauseStateChangedEvent?.Raise(false);
    }
}