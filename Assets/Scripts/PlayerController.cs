using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    private GameLogicController _gameLogicController;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        _gameLogicController = FindObjectOfType<GameLogicController>();
    }

    private void OnEnable()
    {
        _gameLogicController.GoodAnswer += OnGoodAnswer;
        _gameLogicController.BadAnswer += OnBadAnswer;
        _gameLogicController.Win += OnWin;
    }
    private void OnDisable()
    {
        _gameLogicController.GoodAnswer += OnGoodAnswer;
    }

    private void OnBadAnswer()
    {
        var move = Random.Range(0, 4);
        animator.SetFloat("blend-LooseMoves", move);
        animator.SetTrigger("bad-answer");
    }


    private void OnGoodAnswer()
    {
        var move = Random.Range(0, 4);
        animator.SetFloat("blend-VictoryMoves", move);
        animator.SetTrigger("good-answer");
    }

    private void OnWin()
    {
        animator.SetTrigger("win");
    }
}
