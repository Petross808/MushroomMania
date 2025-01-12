using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace State
{
    [CreateAssetMenu(menuName = "Conditions/Composite Condition")]
    public class CompositeCondition : ConditionBase
    {
        /// <summary>
        /// The type of composite condition (And, Or, Xor).
        /// </summary>
        [SerializeField] private ConditionType _conditionType;

        /// <summary>
        /// The list of conditions to evaluate.
        /// </summary>
        [SerializeField] private List<ConditionBase> _conditions;

        [SerializeField] private bool _sortEvaluationByPriority = true;

        [SerializeField] private bool _shortCircuitEvaluation = false;





        private bool _isSorted = false;

        /// <summary>
        /// Evaluates the condition logic based on the conditionType.
        /// </summary>
        /// <returns>True if the composite condition is met; otherwise, false.</returns>
        protected override bool EvaluateCondition(ConditionContext context)
        {
            // Sort conditions by priority before evaluation
            if (_sortEvaluationByPriority && !_isSorted)
            {
                SortConditionsByPriority();
                _isSorted = true;
            }

            switch (_conditionType)
            {
                case ConditionType.And:
                    return EvaluateAndCondition(context);

                case ConditionType.Or:
                    return EvaluateOrCondition(context);

                case ConditionType.Xor:
                    return EvaluateXorCondition(context);

                default:
                    Debug.LogError("CompositeCondition: Unknown condition type.");
                    return false;
            }
        }

        /// <summary>
        /// Evaluates an AND condition: returns true if all child conditions are met.
        /// </summary>
        private bool EvaluateAndCondition(ConditionContext context)
        {
            bool allMet = true;
            foreach (var condition in _conditions)
            {
                if (!condition.Evaluate(context))
                {
                    allMet = false;
                    if (_shortCircuitEvaluation)
                        break;
                }
            }

            if (allMet && TimeMet == -1f)
            {
                TimeMet = Time.timeSinceLevelLoad;
                OnConditionMet?.Raise();
            }

            return allMet;
        }

        /// <summary>
        /// Evaluates an OR condition: returns true if any child condition is met.
        /// </summary>
        private bool EvaluateOrCondition(ConditionContext context)
        {
            bool met = false;
            foreach (var condition in _conditions)
            {
                if (condition.Evaluate(context))
                {
                    met = true;
                    if (_shortCircuitEvaluation)
                        break;

                }
            }

            if (met && TimeMet == -1f)
            {
                TimeMet = Time.timeSinceLevelLoad;
                OnConditionMet?.Raise();
            }

            return met;
        }

        /// <summary>
        /// Evaluates an XOR condition: returns true if exactly one child condition is met.
        /// </summary>
        private bool EvaluateXorCondition(ConditionContext context)
        {
            int metCount = 0;

            foreach (var condition in _conditions)
            {
                if (condition.Evaluate(context))
                {
                    metCount++;
                    // If more than one condition is met, return false
                    if (metCount > 1 && _shortCircuitEvaluation)
                        break;
                }
            }

            if (metCount == 1 && TimeMet == -1f)
            {
                TimeMet = Time.timeSinceLevelLoad;
                OnConditionMet?.Raise();
            }

            return metCount == 1;
        }

        /// <summary>
        /// Sorts the conditions array based on priority levels from highest to lowest.
        /// </summary>
        protected void SortConditionsByPriority()
        {
            //sort the conditions in descending order of priority level
            _conditions = _conditions.OrderByDescending(c => c.PriorityLevel).ToList();
        }

        /// <summary>
        /// Resets the composite condition and all its child conditions.
        /// </summary>
        public override void ResetCondition()
        {
            base.ResetCondition();
            foreach (var condition in _conditions)
            {
                condition.ResetCondition();
            }
        }
    }
}