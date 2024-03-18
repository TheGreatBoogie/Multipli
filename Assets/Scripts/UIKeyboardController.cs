using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIKeyboardController : MonoBehaviour
{
    private Label _answerLabel;
    private Label _calculToResolveLabel;
    private Label _scoreLabel;
    private GameLogicController _gameLogicController;
    private VisualElement _root;

    private void Awake()
    {
        // Find the GameLogicController in the scene
        _gameLogicController = FindObjectOfType<GameLogicController>();
        
        _root = GetComponent<UIDocument>().rootVisualElement;
        _answerLabel = _root.Q<Label>("Answer");
        _calculToResolveLabel = _root.Q<Label>("CalculToResolve");
        _scoreLabel = _root.Q<Label>("Score");
        InitializeButtons(_root);
    }

    private void OnEnable()
    {
        _root.style.display = DisplayStyle.None;
        // Subscribe to GameLogicController events
        _gameLogicController.OnNewProblem += UpdateTextBlock;
        _gameLogicController.OnScoreChanged += UpdateScore;

        OnNumpadClear();    
    }

    private void OnDisable()
    {
        _gameLogicController.OnNewProblem -= UpdateTextBlock;
        _gameLogicController.OnScoreChanged -= UpdateScore;
    }
    
    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (_gameLogicController != null)
        {
            _gameLogicController.OnNewProblem -= UpdateTextBlock;
            _gameLogicController.OnScoreChanged -= UpdateScore;
        }
    }

    private void InitializeButtons(VisualElement root)
    {
        for (int i = 0; i < 10; i++)
        {
            Button button = root.Q<Button>("button" + i);
            if (button != null)
            {
                int number = i; // Local copy for the closure
                button.RegisterCallback<ClickEvent>(ev => OnNumPadPressed(number.ToString()));
            }
        }

        root.Q<Button>("button-clear").RegisterCallback<ClickEvent>(ev => OnNumpadClear());
        root.Q<Button>("button-ok").RegisterCallback<ClickEvent>(ev => OnNumpadValidate());
    }

    private void OnNumPadPressed(string number)
    {
        if (_answerLabel.text == "?")
        {
            _answerLabel.text = number;
        }
        else
        {
            _answerLabel.text += number;
        }
    }

    private void OnNumpadClear()
    {
            _answerLabel.text = "";
    }

    private void OnNumpadValidate()
    {
        if (int.TryParse(_answerLabel.text, out int answer))
        {
            _gameLogicController.CheckAnswer(answer);
        }
        //OnNumpadClear();
    }

    private void UpdateTextBlock(string problem)
    {
        _calculToResolveLabel.text = problem;
        _answerLabel.text = "?";
    }
    
    private void UpdateScore(int newScore)
    {
        _scoreLabel.text = newScore.ToString();
    }

    public void DisplayPanel()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    private void HidePanel()
    {
        _root.style.display = DisplayStyle.None;
    }


}
