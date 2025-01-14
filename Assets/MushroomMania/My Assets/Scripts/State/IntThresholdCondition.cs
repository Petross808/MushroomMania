using State;
using TypesAdvanced;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Int Threshold")]
public class IntThresholdCondition : ConditionBase
{
    [SerializeField] IntVariable _value;
    [SerializeField] CompareType _compareType;
    [SerializeField] int _threshold;

    protected override bool EvaluateCondition(ConditionContext conditionContext)
    {
        switch(_compareType)
        {
            case CompareType.LessThan:
                return _value.Value < _threshold;
            case CompareType.LessThanOrEqual:
                return _value.Value <= _threshold;
            case CompareType.Equal:
                return _value.Value == _threshold;
            case CompareType.GreaterThanOrEqual:
                return _value.Value >= _threshold;
            case CompareType.GreaterThan:
                return _value.Value > _threshold;
            default:
                return false;
        }
    }
}
