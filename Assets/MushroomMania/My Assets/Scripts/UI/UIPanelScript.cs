using EventSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace UISystem {

    [RequireComponent(typeof(UIDocument))]
    public class UIPanelScript : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private int _priority;
        [SerializeField] private bool _closeableByInput;
        [SerializeField] private bool _pausesGame;
        [SerializeField] private bool _invertSetOpen;

        private bool _open;
        private UIDocument _document;

        public bool IsOpen => _open;
        public int Priority => _priority;
        public bool CloseableByInput => _closeableByInput;
        public bool PausesGame => _pausesGame;

        private void Awake()
        {
            _document = GetComponent<UIDocument>();
            _open = false;
            _document.rootVisualElement.visible = false;
            _uiManager.UiScripts.Add(this);
        }

        public void SetOpen(bool setState)
        {
            if (setState ^ _invertSetOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        public void Open()
        {
            _document.sortingOrder = _priority;
            _open = true;
            _document.rootVisualElement.visible = true;
            _uiManager.OnUIChanged();
        }

        public void Close()
        {
            _open = false;
            _document.rootVisualElement.visible = false;
            _uiManager.OnUIChanged();
        }
    }
}