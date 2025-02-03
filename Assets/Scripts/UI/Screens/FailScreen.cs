using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class FailScreen : Window
    {
        [SerializeField] private Button _reviveButton;
        [SerializeField] private Button _replayButton;

        public event Action ReviveButtonClicked;
        public event Action ReplayButtonClicked;
    }
}