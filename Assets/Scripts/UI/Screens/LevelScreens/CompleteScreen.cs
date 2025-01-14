using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.LevelScreens
{
    public class CompleteScreen : Window
    {
        [SerializeField] private Button _nextLevelButton;

        public event Action NextLeveleButtonClicked;
    }
}