using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private int _hungerAmount;
    
    public void IncreaseHunger(int amount)
    {
        _hungerAmount += amount;
        slider.value = _hungerAmount;
    }

    private void OnDestroy()
    {
        slider.value = 0;
    }
}
