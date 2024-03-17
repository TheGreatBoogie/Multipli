using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void OnBadAnswer()
    {
        var move = Random.Range(0, 4);
        animator.SetFloat("blend-LooseMoves", move);
        animator.SetTrigger("bad-answer");
    }
    
    public void OnGoodAnswer()
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
