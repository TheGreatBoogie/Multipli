using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameLogicController : MonoBehaviour
{
    private MainCameraController _mainCameraController;
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<string> OnNewProblem;
    
    [SerializeField] private GameEvent GoodAnswerEvent;
    [SerializeField] private GameEvent BadAnswerEvent;
    public event Action Win;
    private int _goodAnswer;

    private void Awake()
    {
        _mainCameraController = FindObjectOfType<MainCameraController>();
    }

    
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
            GoodAnswerEvent.Raise(this, null);
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
                BadAnswerEvent.Raise(this, null);
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
