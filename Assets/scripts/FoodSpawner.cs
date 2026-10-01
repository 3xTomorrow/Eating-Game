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
        if (!GenericFood.HasFood)
        {
            Instantiate(foodPrefab, transform.position + new Vector3(0,3,0), transform.rotation);
        }
    }

    private void OnDestroy()
    {
        RedButton.OnRedButtonPress -= RedButtonOnOnRedButtonPress;
    }
}
