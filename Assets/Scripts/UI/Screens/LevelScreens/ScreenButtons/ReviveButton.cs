using GameService.ReviveService;
using UnityEngine;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class ReviveButton : MonoBehaviour
    {
        [SerializeField] private Reviver _reviver;
        [SerializeField] private FailScreen _failScreen;

        public void OnReviveClick() =>
            OnRevive();

        private void OnRevive()
        {
            _failScreen.Close();
            ContinueGame();
            _reviver.Revived();
        }

        private void ContinueGame() =>
            Time.timeScale = 1f;
    }
}