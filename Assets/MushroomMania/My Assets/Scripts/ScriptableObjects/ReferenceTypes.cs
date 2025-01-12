using Types;
using UnityEngine;

// Modified file from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

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


    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Types/Variables/Bool", order = 1)]
    public class BoolVariable : ScriptableDataType<bool> { }

    [System.Serializable]
    public class BoolReference : BaseReference<bool>
    {
        public BoolVariable Variable;
        public bool Value => UseConstant ? ConstantValue : Variable.Value;
    }

    [CreateAssetMenu(fileName = "IntVariable", menuName = "Types/Variables/Int", order = 2)]
    public class IntVariable : ScriptableDataType<int> { }

    [System.Serializable]
    public class IntReference : BaseReference<int>
    {
        public IntVariable Variable;
        public int Value => UseConstant ? ConstantValue : Variable.Value;
    }

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Types/Variables/Float", order = 3)]
    public class FloatVariable : ScriptableDataType<float> { }

    [System.Serializable]
    public class FloatReference : BaseReference<float>
    {
        public FloatVariable Variable;

        public float Value => UseConstant ? ConstantValue : Variable.Value;
    }

    [CreateAssetMenu(fileName = "StringVariable", menuName = "Types/Variables/String", order = 4)]
    public class StringVariable : ScriptableDataType<string> { }

    [System.Serializable]
    public class StringReference : BaseReference<string>
    {
        public StringVariable Variable;
        public string Value => UseConstant ? ConstantValue : Variable.Value;
    }

    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Types/Variables/Vector3", order = 5)]
    public class Vector3Variable : ScriptableDataType<Vector3> { }

    [System.Serializable]
    public class Vector3Reference : BaseReference<Vector3>
    {
        public Vector3Variable Variable;
        public Vector3 Value => UseConstant ? ConstantValue : Variable.Value;
    }
}