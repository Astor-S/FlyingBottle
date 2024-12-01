using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _homeButton;

    public event Action HomeButtonClicked;

    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button HomeButton => _homeButton;

    private void OnEnable()
    {
        _homeButton.onClick.AddListener(OnHomeButtonClick);
    }

    private void OnDisable()
    {
        _homeButton.onClick.RemoveListener(OnHomeButtonClick);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        WindowGroup.alpha = 1f;
        gameObject.SetActive(true);
    }

    private void OnHomeButtonClick()
    {
        HomeButtonClicked?.Invoke();
    }
}