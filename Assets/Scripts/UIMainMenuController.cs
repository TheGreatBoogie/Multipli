using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class UIMainMenuController : MonoBehaviour
{
    private GameLogicController _gameLogicController;
    private VisualElement _root;
    [FormerlySerializedAs("EnterOptions")] [SerializeField] private GameEvent DisplayOptions;
    [FormerlySerializedAs("EnterGame")] [SerializeField] private GameEvent MoveCameraToMainGame;
    
    private void Awake()
    {
        // Find the GameLogicController in the scene
        _gameLogicController = FindObjectOfType<GameLogicController>();
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("button_new_game").RegisterCallback<ClickEvent>(evt => TriggerEnterGame());
        _root.Q<Button>("button_options").RegisterCallback<ClickEvent>(evt => DisplayOptions.Raise(this, null));
    }

    private void TriggerEnterGame()
    {
        MoveCameraToMainGame.Raise(this, null);
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
