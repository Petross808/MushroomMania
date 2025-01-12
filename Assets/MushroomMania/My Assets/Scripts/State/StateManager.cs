using System.Collections.Generic;
using UnityEngine;

namespace State
{
    /// <summary>
    /// Manages the game state by evaluating win and loss conditions.
    /// </summary>
    public class StateManager : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Reset all conditions on start")]
        private bool _resetAllConditionsOnStart = true;

        /// <summary>
        /// The condition that determines if the player wins.
        /// </summary>
        [SerializeField]
        [Tooltip("The condition that determines if the player wins")]
        private ConditionBase _winCondition;

        /// <summary>
        /// The condition that determines if the player loses.
        /// </summary>
        [SerializeField]
        [Tooltip("The condition that determines if the player loses")]
        private ConditionBase _loseCondition;

        [SerializeField]
        [Tooltip("Set of optional conditions related to acheivements")]
        private List<ConditionBase> _achievementConditions;

        /// <summary>
        /// Indicates whether the game has ended.
        /// </summary>
        private bool _gameEnded = false;

        private ConditionContext _conditionContext;

        private void Awake()
        {
            // Wrap the two objects inside the context envelope
            _conditionContext = new ConditionContext();
        }

        private void Start()
        {
            if (_resetAllConditionsOnStart)
                ResetConditions();
        }

        /// <summary>
        /// Handles the logic when the player wins.
        /// </summary>
        protected virtual void HandleWin()
        {
            Debug.Log($"Player Wins! Win condition met at {_winCondition.TimeMet} seconds.");

            // Implement win logic here, such as:
            // - Displaying a victory screen
            // - Transitioning to the next level
            // - Awarding points or achievements
            // - Playing a victory sound or animation

            // Example:
            // UIManager.Instance.ShowVictoryScreen();
            // SceneManager.LoadScene("NextLevel");
        }

        /// <summary>
        /// Handles the logic when the player loses.
        /// </summary>
        protected virtual void HandleLoss()
        {
            Debug.Log($"Player Loses! Lose condition met at {_loseCondition.TimeMet} seconds.");

            // Implement loss logic here, such as:
            // - Displaying a game over screen
            // - Offering a restart option
            // - Reducing player lives
            // - Playing a defeat sound or animation

            // Example:
            // UIManager.Instance.ShowGameOverScreen();
            // GameManager.Instance.RestartLevel();
        }

        /// <summary>
        /// Resets the win and loss conditions.
        /// Call this method when restarting the game or level.
        /// </summary>
        public void ResetConditions()
        {
            // Reset the gameEnded flag
            _gameEnded = false;

            // Reset the win condition
            if (_winCondition != null)
                _winCondition.ResetCondition();

            // Reset the lose condition
            if (_loseCondition != null)
                _loseCondition.ResetCondition();

            // Reset the achievement conditions
            if (_achievementConditions != null)
            {
                foreach (var achievmentCondition in _achievementConditions)
                {
                    if (achievmentCondition != null)
                        achievmentCondition.ResetCondition();
                }
            }
        }

        /// <summary>
        /// Move code from Update to HandleTick to perform the tasks at a slower rate
        /// </summary>
        public void HandleTick()
        {
            // If the game has already ended, no need to evaluate further
            if (_gameEnded)
                return;

            // Evaluate the win condition
            if (_winCondition != null && _winCondition.Evaluate(_conditionContext))
            {
                HandleWin();
                // Set gameEnded to true to prevent further updates
                _gameEnded = true;
                // Optionally, disable this component
                // enabled = false;
            }
            // Evaluate the lose condition only if the win condition is not met
            else if (_loseCondition != null && _loseCondition.Evaluate(_conditionContext))
            {
                HandleLoss();
                // Set gameEnded to true to prevent further updates
                _gameEnded = true;
                // Optionally, disable this component
                // enabled = false;
            }

            // Evaluate the achievement conditions
            foreach (var achievmentCondition in _achievementConditions)
            {
                if (achievmentCondition != null && achievmentCondition.Evaluate(_conditionContext))
                {
                    //do something here
                }
            }
        }
    }
}