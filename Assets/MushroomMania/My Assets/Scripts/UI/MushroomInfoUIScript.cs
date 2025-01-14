using EventSystem;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument)), RequireComponent(typeof(UIPanelScript))]
public class MushroomInfoUIScript : MonoBehaviour
{
    [SerializeField] MushroomInfo _shownInUpgrade;
    [SerializeField] List<MushroomInfo> _levels;

    [SerializeField] GameEvent _onButtonClickEvent;
    private UIPanelScript _uiPanelScript;

    private UIDocument _document;
    private Button _resumeButton;

    private List<Button> _menuButtons = new();

    void Awake()
    {
        _uiPanelScript = GetComponent<UIPanelScript>();
        _document = GetComponent<UIDocument>();

        _resumeButton = _document.rootVisualElement.Q<Button>("ResumeButton");
        _resumeButton.RegisterCallback<ClickEvent>(ResumeGame);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void ResumeGame(ClickEvent evt)
    {
        _uiPanelScript.Close();
    }

    private void OnDestroy()
    {
        _resumeButton.UnregisterCallback<ClickEvent>(ResumeGame);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        _onButtonClickEvent.Raise();
    }

    public void ShowUpgrade(int level)
    {
        _shownInUpgrade.Copy(_levels[level]);
        _uiPanelScript.Open();
    }
}
