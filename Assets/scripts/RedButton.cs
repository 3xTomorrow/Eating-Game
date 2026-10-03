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
    
    public override void OnPress()
    {
        OnRedButtonPress?.Invoke();
    }
}
