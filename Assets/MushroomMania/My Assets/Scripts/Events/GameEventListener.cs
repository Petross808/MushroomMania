using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace EventSystem
{
    /// <summary>
    /// Listens for a zero-parameter game event and invokes a response
    /// </summary>
    /// <see cref="GameEvent"/>
    [AddComponentMenu("Events/Game Event Listener")]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Specify the game event (scriptable object) which will raise the event")]
        private GameEvent _event;

        [SerializeField]
        private UnityEngine.Events.UnityEvent _response;

        private void Awake()
        {
            if (_event == null)
                throw new System.Exception("Game Event is not set in GameEventListener " + this.name); 
        }

        private void OnEnable() => _event.RegisterListener(this);

        private void OnDisable() => _event.UnregisterListener(this);

        public virtual void OnEventRaised() => _response?.Invoke();
    }
}