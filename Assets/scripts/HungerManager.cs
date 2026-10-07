using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    [SerializeField] private PointerInputManager input;
    
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
            print("You are full!");
            input.enabled = false;
            _isFull = true;
        }
    }
    
    public static void IncreaseHunger(int amount)
    {
        _hungerAmount += amount;
        _slider.value = _hungerAmount;
    }
}
