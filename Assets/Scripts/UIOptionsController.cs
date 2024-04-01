using UnityEngine;
using UnityEngine.UIElements;

public class UIOptionsController : MonoBehaviour
{
    private VisualElement _root;
    [SerializeField] private GameEvent ExitOptions;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _root.Q<Button>("button_ok").RegisterCallback<ClickEvent>(ev => ExitOptions.Raise(this, null));
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

}
