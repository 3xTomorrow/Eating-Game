using UnityEngine;
using System;

public class RedButton : MonoBehaviour, IButton
{
    public static event Action OnRedButtonPress ;
    
    public void OnPress()
    {
        OnRedButtonPress?.Invoke();
    }
}
