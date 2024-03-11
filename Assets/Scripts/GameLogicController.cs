using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLogicController : MonoBehaviour
{
    private MainCameraController _mainCameraController;
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<string> OnNewProblem;
    public event Action GoodAnswer;
    public event Action BadAnswer;
    public event Action Win;
    public event Action MainGameEnter;
    public event Action MainMenuEnter;
    public event Action MainGameExit;
    public event Action MainMenuExit;

    private int _goodAnswer;

    private void Awake()
    {
        _mainCameraController = FindObjectOfType<MainCameraController>();
    }

    private void OnEnable()
    {
        _mainCameraController.MainGameTriggerEnter += MainCameraControllerOnMainGameEnter;
        _mainCameraController.MainGameTriggerExit += MainCameraControllerOnMainGameExit;
        _mainCameraController.MainMenuTriggerEnter += MainCameraControllerOnMenuEnter;
        _mainCameraController.MainMenuTriggerExit += MainCameraControllerOnMenuExit;
    }


    private void OnDisable()
    {
        _mainCameraController.MainGameTriggerEnter -= MainCameraControllerOnMainGameEnter;
        _mainCameraController.MainGameTriggerExit -= MainCameraControllerOnMainGameExit;
        _mainCameraController.MainMenuTriggerEnter -= MainCameraControllerOnMenuEnter;
        _mainCameraController.MainMenuTriggerExit -= MainCameraControllerOnMenuExit;
    }
    
    private void Start()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
        GenerateNewProblem();
    }
    
    private void MainCameraControllerOnMenuEnter()
    {
        MainMenuEnter?.Invoke();
    }
    private void MainCameraControllerOnMainGameEnter()
    {
        MainGameEnter?.Invoke();
    }
    
    private void MainCameraControllerOnMenuExit()
    {
        MainMenuExit?.Invoke();
    }

    private void MainCameraControllerOnMainGameExit()
    {
        MainGameExit?.Invoke();
    }

    public void CheckAnswer(int playerAnswer)
    {
        if (playerAnswer == _goodAnswer)
        {
            Score++;
            OnScoreChanged?.Invoke(Score);
            GoodAnswer?.Invoke();
            GenerateNewProblem();
        }
        else
        {
            // Secret code check
            if (playerAnswer == 35383773)
            {
                Win?.Invoke();
            }
            else
            {
                // Handle incorrect answer if needed
                BadAnswer?.Invoke();
                GenerateNewProblem();
            }
        }
    }

    private void GenerateNewProblem()
    {
        int firstNumber = Random.Range(1, 12);
        int secondNumber = Random.Range(1, 12);
        _goodAnswer = firstNumber * secondNumber;
        OnNewProblem?.Invoke($"{firstNumber} x {secondNumber} = ");
    }
}
