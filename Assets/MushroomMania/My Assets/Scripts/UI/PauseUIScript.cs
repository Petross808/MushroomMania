using EventSystem;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument)), RequireComponent(typeof(UIPanelScript))]
public class PauseUIScript : MonoBehaviour
{
    [SerializeField] GameEvent _onMenuButtonClickedEvent;
    [SerializeField] GameEvent _onButtonClickEvent;
    private UIPanelScript _uiPanelScript;

    private UIDocument _document;
    private Button _resumeButton;
    private Button _homeButton;

    private List<Button> _menuButtons = new();

    void Awake()
    {
        _uiPanelScript = GetComponent<UIPanelScript>();
        _document = GetComponent<UIDocument>();
        _resumeButton = _document.rootVisualElement.Q<Button>("ResumeButton");
        _resumeButton.RegisterCallback<ClickEvent>(ResumeGame);

        _homeButton = _document.rootVisualElement.Q<Button>("MenuButton");
        _homeButton.RegisterCallback<ClickEvent>(OpenMainMenu);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OpenMainMenu(ClickEvent evt)
    {
        _onMenuButtonClickedEvent.Raise();
    }

    private void ResumeGame(ClickEvent evt)
    {
        _uiPanelScript.Close();
    }

    private void OnDestroy()
    {
        _resumeButton.UnregisterCallback<ClickEvent>(ResumeGame);
        _homeButton.UnregisterCallback<ClickEvent>(OpenMainMenu);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        _onButtonClickEvent.Raise();
    }
}
