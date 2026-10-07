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
            Instantiate(foodPrefab, transform.position + new Vector3(0,3,0), new  Quaternion(0,0,0,0));
        }
    }

    private void OnDestroy()
    {
        RedButton.OnRedButtonPress -= RedButtonOnOnRedButtonPress;
    }
}
