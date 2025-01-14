using UnityEngine;

namespace TypesAdvanced
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Types/Variables/Bool", order = 1)]
    public class BoolVariable : ScriptableDataType<bool> { }

    [System.Serializable]
    public class BoolReference : BaseReference<bool>
    {
        public BoolVariable Variable;
        public bool Value => UseConstant ? ConstantValue : Variable.Value;
    }
}