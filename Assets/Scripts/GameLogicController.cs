using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLogicController : MonoBehaviour
{
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<string> OnNewProblem;
    public event Action GoodAnswer;
    public event Action BadAnswer;
    public event Action Win;


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
        OnNewProblem?.Invoke($"{firstNumber} x {secondNumber}");
    }
}
