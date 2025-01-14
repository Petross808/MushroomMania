using EventSystem;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument)), RequireComponent(typeof(UIPanelScript))]
public class MenuUiScript : MonoBehaviour
{
    [SerializeField] GameEvent _onPlayButtonClicked;
    [SerializeField] GameEvent _onButtonClickEvent;

    private UIDocument _document;
    private Button _playButton;
    private Button _quitButton;

    private List<Button> _menuButtons = new();

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _playButton = _document.rootVisualElement.Q<Button>("PlayButton");
        _playButton.RegisterCallback<ClickEvent>(PlayNewGame);

        _quitButton = _document.rootVisualElement.Q<Button>("ExitButton");
        _quitButton.RegisterCallback<ClickEvent>(QuitGame);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void PlayNewGame(ClickEvent evt)
    {
        _onPlayButtonClicked?.Raise();
    }

    private void QuitGame(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        _onButtonClickEvent.Raise();
    }

    private void OnDestroy()
    {
        _playButton.UnregisterCallback<ClickEvent>(PlayNewGame);
        _quitButton.UnregisterCallback<ClickEvent>(QuitGame);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }
}