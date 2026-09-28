using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Food[] foods;

    private void Start()
    {
        RedButton.OnRedButtonPress += RedButtonOnOnRedButtonPress;
    }

    private void RedButtonOnOnRedButtonPress()
    {
        print("button pressed");
        
        var foodSo = Instantiate(foodPrefab, transform.position, transform.rotation);
        if (foodSo != null && foodSo.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
        {
            spriteRenderer.sprite = foods[0].uneatenSprite;
        }
    }
}
