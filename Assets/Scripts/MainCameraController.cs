using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MainCameraController : MonoBehaviour
{
    private GameLogicController _gameLogicController;

    public GameObject colliderMainGame;
    public GameObject colliderMenu;

    [SerializeField] private GameEvent MainGameEnter;
    [SerializeField] private GameEvent MainMenuEnter;
    [SerializeField] private GameEvent MainGameExit;
    [SerializeField] private GameEvent MainMenuExit;
    
    private void Awake()
    {
        _gameLogicController = FindObjectOfType<GameLogicController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == colliderMainGame.GetComponent<Collider>())
        {
            MainGameEnter.Raise(this, null);
        } else if (other == colliderMenu.GetComponent<Collider>())
        {
            MainMenuEnter.Raise(this, null);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == colliderMainGame.GetComponent<Collider>())
        {
            MainGameExit.Raise(this, null);
        } else if (other == colliderMenu.GetComponent<Collider>())
        {
            MainMenuExit.Raise(this, null);
        }
    }
}
