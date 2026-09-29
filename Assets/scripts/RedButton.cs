using UnityEngine;
using System;
using System.Collections;

public class RedButton : MonoBehaviour, IButton, IPressable
{
    [SerializeField] private Sprite unpressedSprite;
    [SerializeField] private Sprite pressedSprite;
    
    private SpriteRenderer _spriteRenderer;
    
    public static event Action OnRedButtonPress ;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void OnPress()
    {
        _spriteRenderer.sprite = pressedSprite;
        OnRedButtonPress?.Invoke();
    }

    public void UnpressedSprite()
    {
        _spriteRenderer.sprite = unpressedSprite;
    }

    public void PressedSprite()
    {
        _spriteRenderer.sprite = pressedSprite;
    }

}
