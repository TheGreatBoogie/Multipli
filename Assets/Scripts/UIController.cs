using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        
        Button buttonOne = root.Q<Button>("button-one");
        Button buttonTwo = root.Q<Button>("button-two");
        Button buttonThree = root.Q<Button>("button-three");
        Button buttonFour = root.Q<Button>("button-four");
        Button buttonFive = root.Q<Button>("button-five");
        Button buttonSix = root.Q<Button>("button-six");
        Button buttonSeven = root.Q<Button>("button-seven");
        Button buttonHeight = root.Q<Button>("button-height");
        Button buttonNine = root.Q<Button>("button-nine");
        Button buttonZero = root.Q<Button>("button-zero");
        Button buttonClear = root.Q<Button>("button-clear");
        Button buttonOk = root.Q<Button>("button-ok");

        TextField textField = root.Q<TextField>("Answer");
    
        buttonOk.clicked += () => Debug.Log("Value: " + textField.text);
    }
}
