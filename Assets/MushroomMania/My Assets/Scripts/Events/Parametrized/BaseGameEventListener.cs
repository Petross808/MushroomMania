using Items;
using UnityEngine;

// Modified file from Niall McGuinness' repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace EventSystem
{
    /// <summary>
    /// Generic listener class that listens for events of type T.
    /// Listens for events raised by BaseGameEvent<T> and responds using UnityEvent<T>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="BaseGameEvent{T}"/>
    public class BaseGameEventListener<T> : MonoBehaviour
    {
        // The game event that this listener subscribes to.
        [SerializeField]
        [Tooltip("Specify the game event (scriptable object) which will raise the event")]
        private BaseGameEvent<T> _event;

        // The UnityEvent response that will be invoked when the event is raised.
        [SerializeField]
        private UnityEngine.Events.UnityEvent<T> Response;

        private void Awake()
        {
            if (_event == null)
                throw new System.Exception("Game Event is not set in BaseGameEventListener " + this.name);
        }

        // Register the listener with the event when enabled.
        private void OnEnable() => _event.RegisterListener(this);

        // Unregister the listener from the event when disabled.
        private void OnDisable() => _event.UnregisterListener(this);

        // Called when the event is raised, invoking the response.
        public virtual void OnEventRaised(T data) => Response?.Invoke(data);
    }
}