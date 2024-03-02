using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class     PlayerController : MonoBehaviour
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
    }
    private void OnDisable()
    {
        _gameLogicController.GoodAnswer += OnGoodAnswer;
    }

    private void OnBadAnswer()
    {
        var move = Random.Range(0, 2);
        animator.SetFloat("blend-LooseMoves", move);
        animator.SetTrigger("loose");
    }


    private void OnGoodAnswer()
    {
        var move = Random.Range(0, 5);
        Debug.Log(move);
        animator.SetFloat("blend-VictoryMoves", move);
        animator.SetTrigger("victory");
    }
}
