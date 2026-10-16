using System;
using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    public static event EventHandler OnFullnessReached;
    
    private static Slider _slider;
    private static float _hungerAmount;
    private bool _isFull;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _hungerAmount = _slider.value;
    }
    
    private void Update()
    {
        if (_hungerAmount >= _slider.maxValue && !_isFull)
        {
            _isFull = true;
            OnFullnessReached?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public static void IncreaseHunger(int amount)
    {
        _hungerAmount += amount;
        _slider.value = _hungerAmount;
    }
}
