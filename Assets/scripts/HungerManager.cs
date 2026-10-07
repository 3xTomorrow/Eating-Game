using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void IncreaseHunger(int amount)
    {
        slider.value += amount;
    }

    private void OnDestroy()
    {
        slider.value = 0;
    }
}
