using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

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
        _gameLogicController.GoodAnswer += PlayerDance;
    }

    private void PlayerDance()
    {
        animator.SetTrigger("dancing");
    }
}
