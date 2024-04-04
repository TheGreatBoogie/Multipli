using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIKeyboardController : MonoBehaviour
{
    private Label _answerLabel;
    private Label _calculToResolveLabel;
    private Label _scoreLabel;
    private Label _timer;
    private GameLogicController _gameLogicController;
    private VisualElement _root;
    private VisualElement _keyboard;
    private CountdownTimer _countdownTimer;

    private void Awake()
    {
        // Find the GameLogicController in the scene
        _gameLogicController = FindObjectOfType<GameLogicController>();
        
        _root = GetComponent<UIDocument>().rootVisualElement;
        _answerLabel = _root.Q<Label>("Answer");
        _calculToResolveLabel = _root.Q<Label>("CalculToResolve");
        _scoreLabel = _root.Q<Label>("Score");
        _keyboard = _root.Q<VisualElement>("Keyboard");
        _timer = _root.Q<Label>("timer");
        _countdownTimer = gameObject.GetComponent<CountdownTimer>();
        InitializeButtons(_root);
    }

    private void OnEnable()
    {
        _root.style.display = DisplayStyle.None;
        OnNumpadClear();    
    }

    private void Start()
    {
        HideTimerLabel();
        HidePanel();
    }

    private void HideTimerLabel()
    {
        _timer.style.display = DisplayStyle.None;
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

    public void CheckAndStartCountDown()
    {
        if (PlayerPrefs.GetInt("isTimer") == 1)
        {
            _timer.style.display = DisplayStyle.Flex;
            _countdownTimer.StartCountdown();
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

    public void DisplayNewProblem(Component comp ,object problem)
    {
        _calculToResolveLabel.text = (string)problem;
        _answerLabel.text = "?";
    }
    
    public void UpdateScore(Component comp ,object newScore)
    {
        _scoreLabel.text = newScore.ToString();
    }

    public void DisplayPanel(Component comp, object obj)
    {
        _root.style.display = DisplayStyle.Flex;
    }

    private void HidePanel()
    {
        _root.style.display = DisplayStyle.None;
    }

    public void DisplayKeyBoard()
    {
        _keyboard.style.display = DisplayStyle.Flex;
    }

    public void HideKeyBoard(Component comp, object obj)
    {
        _keyboard.style.display = DisplayStyle.None;
    }

    public void UpdateTimerLabel()
    {
        _timer.text = _countdownTimer.GetCurrentTime().ToString();
    }
    
}
