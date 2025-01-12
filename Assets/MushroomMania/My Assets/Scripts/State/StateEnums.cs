using System;

namespace State
{
    /// <summary>
    /// Used in the StateManager to determine how to evaluate a condition.
    /// </summary>
    [Serializable]
    public enum ConditionType
    {
        And,
        Or,
        Xor
    }

    /// <summary>
    /// Used in the StateManager to determine how to evaluate a condition.
    /// </summary>
    [Serializable]
    public enum EvaluateStrategy
    {
        /// <summary>
        /// Always evaluate the condition, regardless of whether it is met.
        /// </summary>
        EvaluateAlways,

        /// <summary>
        /// Evaluate the condition until it is met, then stop evaluating.
        /// </summary>
        EvaluateUntilMet
    }

    /// <summary>
    /// A five-level priority system used to determine the importance of a task, event, or object.
    /// </summary>
    [Serializable]
    public enum PriorityLevel
    {
        Highest = 1,
        High = 2,
        Medium = 3,
        Low = 4,
        Lowest = 5
    }
}