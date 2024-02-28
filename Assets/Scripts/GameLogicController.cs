using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLogicController : MonoBehaviour
{
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<string> OnNewProblem;

    private int _goodAnswer;

    private void Start()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
        GenerateNewProblem();
    }

    public void CheckAnswer(int playerAnswer)
    {
        if (playerAnswer == _goodAnswer)
        {
            Score++;
            OnScoreChanged?.Invoke(Score);
            GenerateNewProblem();
        }
        else
        {
            // Handle incorrect answer if needed
            GenerateNewProblem();
        }
    }

    private void GenerateNewProblem()
    {
        int firstNumber = Random.Range(1, 12);
        int secondNumber = Random.Range(1, 12);
        _goodAnswer = firstNumber * secondNumber;
        OnNewProblem?.Invoke($"{firstNumber} x {secondNumber}");
    }
}
