using UnityEngine;

namespace TypesAdvanced
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Types/Variables/Vector3", order = 5)]
    public class Vector3Variable : ScriptableDataType<Vector3> { }

    [System.Serializable]
    public class Vector3Reference : BaseReference<Vector3>
    {
        public Vector3Variable Variable;
        public Vector3 Value => UseConstant ? ConstantValue : Variable.Value;
    }
}