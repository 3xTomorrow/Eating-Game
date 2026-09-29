using System;
using UnityEngine;
using System.Collections.Generic;

public class GenericFood : MonoBehaviour, IButton
{
    [SerializeField] private List<Food> foods;
    
    private SpriteRenderer _spriteRenderer;
    
    public static bool HasFood = false;
    private bool _eaten = false;
    
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        HasFood = true;
        _spriteRenderer.sprite = foods[0].uneatenSprite;
        
    }

    public void OnPress()
    {
        if (!_eaten)
        {
            _spriteRenderer.sprite = foods[0].eatenSprite;
        }
    }

    public void OnDestroy()
    {
        HasFood = false;
        _eaten = false;
    }
}
