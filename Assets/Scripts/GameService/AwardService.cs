using UI.Screens;
using UnityEngine;

namespace GameService
{
    public class AwardService : MonoBehaviour
    {
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private AwardScreen _awardScreen;

        private void OnEnable()
        {
            _completeScreen.OnScreenActivated += HandleScreenActivated;
        }

        private void OnDisable()
        {
            _completeScreen.OnScreenActivated -= HandleScreenActivated;
        }

        private void HandleScreenActivated() =>
            _awardScreen.GiveReward();
    }
}