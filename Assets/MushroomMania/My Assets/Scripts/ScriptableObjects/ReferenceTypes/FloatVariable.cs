using UnityEngine;

namespace TypesAdvanced
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Types/Variables/Float", order = 3)]
    public class FloatVariable : ScriptableDataType<float> { }

    [System.Serializable]
    public class FloatReference : BaseReference<float>
    {
        public FloatVariable Variable;

        public float Value => UseConstant ? ConstantValue : Variable.Value;
    }
}