using System;
using UnityEngine;
using UnityEngine.UI;

public class CompleteScreen : Window
{
    [SerializeField] private Button _nextLevelButton;

    public event Action NextLeveleButtonClicked;
}