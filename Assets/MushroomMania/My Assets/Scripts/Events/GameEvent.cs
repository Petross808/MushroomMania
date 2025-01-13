using Types;
using System.Collections.Generic;
using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace EventSystem
{
    /// <summary>
    /// Implements Observer pattern to enable us to notify multiple objects about
    /// any events that happen to the GameEvent they’re observing.
    /// </summary>
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Events/No Params/GameEvent")]
    public class GameEvent : ScriptableGameObject
    {
        private List<GameEventListener> listeners = new();

        [ContextMenu("Raise Event")]
        public virtual void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}