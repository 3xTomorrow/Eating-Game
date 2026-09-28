using UnityEngine;
using System.Collections.Generic;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;

    private void Start()
    {
        RedButton.OnRedButtonPress += RedButtonOnOnRedButtonPress;
    }

    private void RedButtonOnOnRedButtonPress()
    {
        if (!GenericFood.hasFood)
        {
            Instantiate(foodPrefab, transform.position, transform.rotation);
        }
    }

    private void OnDestroy()
    {
        RedButton.OnRedButtonPress -= RedButtonOnOnRedButtonPress;
    }
}
