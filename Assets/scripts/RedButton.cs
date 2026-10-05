using UnityEngine;
using System;
using System.Collections;

public class RedButton : Button, IPressable
{
    public static event Action OnRedButtonPress ;

    protected override void Awake()
    {
        base.Awake();
    }
    
    public new void OnPress()
    {
        base.OnPress();
        OnRedButtonPress?.Invoke();
    }

    public new void OnRelease()
    {
        base.OnRelease();
    }
}
