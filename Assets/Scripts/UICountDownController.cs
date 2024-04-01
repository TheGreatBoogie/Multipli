using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UICountDownController : MonoBehaviour
{
    private VisualElement _root;
    private Label _countdownLabel;
    private CountdownTimer _countdownTimer;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _countdownLabel = _root.Q<Label>("CountDownText");
        _countdownTimer = gameObject.GetComponent<CountdownTimer>();
    }

    private void Start()
    {
        HideCountDown();
    }

    public void DisplayCountDown()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    public void HideCountDown()
    {
        _root.style.display = DisplayStyle.None;
    }

    public void UpdateLabel()
    {
        _countdownLabel.text = _countdownTimer.GetCurrentTime().ToString();
    }
}
