using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEndGameController : MonoBehaviour
{
    private VisualElement _root;
    [SerializeField] private GameEvent RestartGame;
    [SerializeField] private GameEvent GoToMainMenu;
    private Label _scoreLabel;
    
    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("button_restart").RegisterCallback<ClickEvent>(ev => StartNewGame());
        _root.Q<Button>("button_menu").RegisterCallback<ClickEvent>(ev => OnGoToMainMainMenu());
        _scoreLabel = _root.Q<Label>("labelscore");

    }

    private void OnGoToMainMainMenu()
    {
        GoToMainMenu.Raise(this, null);
    }


    private void StartNewGame()
    {
        RestartGame.Raise(this, null);
    }

    private void Start()
    {
        HideUI();
    }
    
    public void HideUI()
    {
        _root.style.display = DisplayStyle.None;
    }
    
    public void ShowUI()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    public void DisplayScore(Component comp, Object obj)
    {
        _scoreLabel.text = $"Score: {obj}";
    }
    
    
}
