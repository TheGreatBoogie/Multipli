using System.Collections.Generic;  
using UnityEngine;  
  
[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]  
public class GameEvent : ScriptableObject  
{  
    HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();  
  
    public void Raise()  
    {  
        foreach (var eventListener in listeners)  
        {  
            eventListener.OnEventRaised();  
        }  
    }  
  
    public void RegisterListener(GameEventListener listener) => listeners.Add(listener);  
    public void UnregisterListener(GameEventListener listener) => listeners.Remove(listener);  
}