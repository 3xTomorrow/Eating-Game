using System.Threading;
using UnityEngine;
using System;

public interface IPressable
{
    public void OnPress();
    
    public void OnRelease();
}
