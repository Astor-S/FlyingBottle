using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class CompleteScreen : Window
    {
        [SerializeField] private Button _nextLevelButton;

        public event Action OnScreenActivated;

        private void OnEnable()
        {
            OnScreenActivated?.Invoke();
        }
    }
}