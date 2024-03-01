using UnityEngine;
using UnityEngine.UIElements;
using System;

public class UIController : MonoBehaviour
{
    private Label _answerLabel;
    private Label _calculToResolve;
    private Label _scoreLabel;
    private GameLogicController _gameLogicController;

    private void Awake()
    {
        // Find the GameLogicController in the scene
        _gameLogicController = FindObjectOfType<GameLogicController>();
        
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _answerLabel = root.Q<Label>("Answer");
        _calculToResolve = root.Q<Label>("CalculToResolve");
        _scoreLabel = root.Q<Label>("Score");
        InitializeButtons(root);
    }

    private void OnEnable()
    {
        // Subscribe to GameLogicController events
        _gameLogicController.OnNewProblem += UpdateCalculToResolve;
        _gameLogicController.OnScoreChanged += UpdateScore;
        OnNumpadClear();    
    }

    private void OnDisable()
    {
        _gameLogicController.OnNewProblem -= UpdateCalculToResolve;
        _gameLogicController.OnScoreChanged -= UpdateScore;
    }
    
    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (_gameLogicController != null)
        {
            _gameLogicController.OnNewProblem -= UpdateCalculToResolve;
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
        _answerLabel.text += number;
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
        OnNumpadClear();
    }

    private void UpdateCalculToResolve(string problem)
    {
        _calculToResolve.text = problem;
    }

    private void UpdateScore(int newScore)
    {
        _scoreLabel.text = newScore.ToString();
        Debug.Log("Score updated");
    }


}
