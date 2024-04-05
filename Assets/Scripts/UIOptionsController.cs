using UnityEngine;
using UnityEngine.UIElements;

public class UIOptionsController : MonoBehaviour
{
    private VisualElement _root;
    [SerializeField] private GameEvent ExitOptions;
    private bool _isTimer = false;
    private int _gameMode = 0;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("button_ok").RegisterCallback<ClickEvent>(ev => ExitOptions.Raise(this, null));
        _root.Q<Button>("button_timer").RegisterCallback<ClickEvent>(ev => ButtonTimerOnclick());
        _root.Q<Button>("button_type").RegisterCallback<ClickEvent>(ev => ButtonGameTypeOnclick());
    }

    private void Start()
    {
        HideOptions();
    }

    public void HideOptions()
    {
        _root.style.display = DisplayStyle.None;
    }

    public void ShowOptions()
    {
        _root.style.display = DisplayStyle.Flex;
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetInt("isTimer", _isTimer ? 1 : 0);
        PlayerPrefs.SetInt("gameMode", _gameMode);
        PlayerPrefs.Save();
        Debug.Log("Options saved");
    }

    public void LoadOptions()
    {
        // Load isTimer and update button label
        if (PlayerPrefs.HasKey("isTimer"))
        {
            _isTimer = PlayerPrefs.GetInt("isTimer", 0) == 1;
            if (_isTimer)
            {
                _root.Q<Button>("button_timer").text = "Timer: On";
            }
            else
            {
                _root.Q<Button>("button_timer").text = "Timer: Off";
            }
        }
        else
        {
            Debug.Log("isTimer key not found... using default");
        }
        
        // Load gameMode and update button label
        if (PlayerPrefs.HasKey("gameMode"))
        {
            _gameMode = PlayerPrefs.GetInt("gameMode", 0);
            
            if (_gameMode == 0)
            {
                _root.Q<Button>("button_type").text = "Type: Multiplication";
            }
            else
            {
                _root.Q<Button>("button_type").text = "Type: Addition";
            }
        }
        else
        {
            Debug.Log("gameMode key not found... using default");
        }
        Debug.Log($"Options loaded: isTimer: {_isTimer} - gameMode: {_gameMode}");
    }

    private void ButtonTimerOnclick()
    {
        _isTimer = !_isTimer;
        if (_isTimer)
        {
            _root.Q<Button>("button_timer").text = "Timer: On";
        }
        else
        {
            _root.Q<Button>("button_timer").text = "Timer: Off";
        }


    }

    private void ButtonGameTypeOnclick()
    {
        Debug.Log("ButtonClicked");
        var labelString = "";
        if (_gameMode == 0)
        {
            _gameMode = 1;
            labelString = "Type: Addition";
            Debug.Log("GameMode was 0 => 1");
        }
        else
        {
            _gameMode = 0;
            labelString= "Type: Multiplication";
            Debug.Log("GameMode was 1 => 0");
        }
        _root.Q<Button>("button_type").text = labelString; 
    }
    
}
