using UnityEngine;

namespace TypesAdvanced
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Types/Variables/String", order = 4)]
    public class StringVariable : ScriptableDataType<string> { }

    [System.Serializable]
    public class StringReference : BaseReference<string>
    {
        public StringVariable Variable;
        public string Value => UseConstant ? ConstantValue : Variable.Value;
    }
}