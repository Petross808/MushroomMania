using UnityEngine;

namespace TypesAdvanced {

    [CreateAssetMenu(fileName = "IntVariable", menuName = "Types/Variables/Int", order = 2)]
    public class IntVariable : ScriptableDataType<int> { }

    [System.Serializable]
    public class IntReference : BaseReference<int>
    {
        public IntVariable Variable;
        public int Value => UseConstant ? ConstantValue : Variable.Value;
    }
}