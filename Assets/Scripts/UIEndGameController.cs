using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEndGameController : MonoBehaviour
{
    private VisualElement _root;
    [SerializeField] private GameEvent RestartGame;
    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("button_newgame").RegisterCallback<ClickEvent>(ev => StartNewGame());
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
    
    
}
