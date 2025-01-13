using EventSystem;
using System.Collections.Generic;
using UnityEngine;

namespace UISystem{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameEvent _onUiChanged;

        private readonly List<UIPanelScript> _uiScripts = new();
        public List<UIPanelScript> UiScripts => _uiScripts;

        private void Awake()
        {
            this.EnsureSingleInstance();
        }

        public void CloseTopMostCloseable()
        {
            List<UIPanelScript> closeable = _uiScripts.FindAll(a => a.IsOpen && a.CloseableByInput);
            if (closeable.Count == 0)
                return;

            UIPanelScript topmost = closeable[0];
            foreach (UIPanelScript script in closeable)
            {
                if (script.Priority > topmost.Priority)
                    topmost = script;
            }

            topmost.Close();
        }

        public void ForceCloseAll()
        {
            foreach (UIPanelScript script in _uiScripts)
            {
                script.Close();
            }
        }

        public void OnUIChanged()
        {
            foreach (UIPanelScript script in _uiScripts)
            {
                if (script.IsOpen && script.PausesGame)
                {
                    _onUiChanged?.Raise();
                    return;
                }
            }

            _onUiChanged?.Raise();
        }

    }
}