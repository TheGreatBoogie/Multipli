using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenuController : MonoBehaviour
{
    private GameLogicController _gameLogicController;
    private VisualElement _root;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    private void Awake()
    {
        // Find the GameLogicController in the scene
        _gameLogicController = FindObjectOfType<GameLogicController>();
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("NewGame").RegisterCallback<ClickEvent>(evt => MoveCamera());
    }

    private void MoveCamera()
    {
        virtualCamera.Priority = 9;
    }

    private void OnEnable()
    {
        // Display/Hide UI based on Camera position
        _gameLogicController.MainMenuEnter += DisplayPanel;
        _gameLogicController.MainMenuExit += HidePanel;
    }

    private void OnDisable()
    {
        // Display/Hide UI based on Camera position
        _gameLogicController.MainMenuEnter -= DisplayPanel;
        _gameLogicController.MainMenuExit -= HidePanel;

    }
    
    private void DisplayPanel()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    private void HidePanel()
    {
        _root.style.display = DisplayStyle.None;
    }
}
