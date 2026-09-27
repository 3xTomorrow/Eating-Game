using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;

    private void Start()
    {
        RedButton.OnRedButtonPress += RedButtonOnOnRedButtonPress;
    }

    private void RedButtonOnOnRedButtonPress()
    {
        print("button pressed");
        
        Instantiate(foodPrefab, transform.position, transform.rotation);
    }
}
