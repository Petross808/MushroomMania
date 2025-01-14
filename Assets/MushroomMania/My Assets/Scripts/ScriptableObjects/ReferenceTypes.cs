using Types;
using UnityEngine;

// Modified file from Niall McGuinness' repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

/// <summary>
/// Contains a set of ScriptableObject(SO) data types (float, int, bool) and reference types that can switch between a local variable (e.g float) or reference to a shared variable (e.g. FloatVariable)
/// </summary>
namespace TypesAdvanced
{
    [System.Serializable]
    public abstract class ScriptableDataType<T> : ScriptableGameObject
    {
        [SerializeField]
        private T value;

        public T Value { get => value; set => this.value = value; }

        public virtual void Set(T value)
        {
            this.value = value;
        }

        public virtual void ResetValue()
        {
            Set(default(T));
        }
    }

    //Generic type to replace BoolReference, IntReference etc

    [System.Serializable]
    public class BaseReference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
    }
}