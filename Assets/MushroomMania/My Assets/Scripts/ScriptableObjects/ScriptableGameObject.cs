using UnityEngine;

// File from a previous project that I wrote https://github.com/Petross808/MazeEscapeUDP

namespace Types
{
    public class ScriptableGameObject : ScriptableObject
    {
    #if UNITY_EDITOR
        [SerializeField] private string _editorName;
        [SerializeField, TextArea(3, 10)] private string _editorDescription;
    #endif
    }
}