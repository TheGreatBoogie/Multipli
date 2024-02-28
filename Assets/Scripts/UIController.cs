using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private int _answerResult;
    private Label _answerLabel;
    public void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _answerLabel = root.Q<Label>("Answer");

        for (int i = 0; i < 10; i++)
        {
            Button button = root.Q<Button>("button" + i);

            if (button != null)
            {
                button.RegisterCallback<ClickEvent>(ev => OnNumPadPressedButton(button));
            }
        }
        root.Q<Button>("button-clear").RegisterCallback<ClickEvent>(ev => OnNumpadClear());
        root.Q<Button>("button-ok").RegisterCallback<ClickEvent>(ev => OnNumpadValidate());
        
    }

    private void OnNumpadValidate()
    {
        throw new NotImplementedException();
    }

    private void OnNumpadClear()
    {
        _answerLabel.text = "";
    }

    private void OnNumPadPressedButton(Button button)
    {
        _answerLabel.text += button.text;
    }
}
