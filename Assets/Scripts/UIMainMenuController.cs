using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenuController : MonoBehaviour
{
    private GameLogicController _gameLogicController;
    private VisualElement _root;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameEvent EnterOptions;
    
    private void Awake()
    {
        // Find the GameLogicController in the scene
        _gameLogicController = FindObjectOfType<GameLogicController>();
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("button_new_game").RegisterCallback<ClickEvent>(evt => MoveCamera());
        _root.Q<Button>("button_options").RegisterCallback<ClickEvent>(evt => EnterOptions.Raise(this, null));
    }

    private void MoveCamera()
    {
        virtualCamera.Priority = 9;
    }

     
    public void DisplayPanel()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    public void HidePanel()
    {
        _root.style.display = DisplayStyle.None;
    }
}
