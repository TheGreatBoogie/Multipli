using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    private GameLogicController _gameLogicController;

    public GameObject colliderMainGame;
    public GameObject colliderMenu;

    public event Action MainGameTriggerEnter;
    public event Action MainMenuTriggerEnter;
    public event Action MainGameTriggerExit;
    public event Action MainMenuTriggerExit;
   
    private void Awake()
    {
        _gameLogicController = FindObjectOfType<GameLogicController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == colliderMainGame.GetComponent<Collider>())
        {
            MainGameTriggerEnter?.Invoke();
        } else if (other == colliderMenu.GetComponent<Collider>())
        {
            MainMenuTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == colliderMainGame.GetComponent<Collider>())
        {
            MainGameTriggerExit?.Invoke();
        } else if (other == colliderMenu.GetComponent<Collider>())
        {
            MainMenuTriggerExit?.Invoke();
        }
    }
}
