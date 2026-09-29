using UnityEngine;
using System;
using System.Collections;

public class RedButton : MonoBehaviour, IButton, IPressable
{
    [SerializeField] private Sprite unpressedSprite;
    [SerializeField] private Sprite pressedSprite;
    
    [SerializeField] private AudioClip buttonPressSound;
    [SerializeField] private AudioClip buttonReleaseSound;
    
    private AudioSource _buttonClickSound;
    private SpriteRenderer _spriteRenderer;
    
    public static event Action OnRedButtonPress ;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _buttonClickSound = GetComponentInChildren<AudioSource>();
    }
    
    public void OnPress()
    {
        _spriteRenderer.sprite = pressedSprite;
        OnRedButtonPress?.Invoke();
    }
    
    public void PressedSprite()
    {
        _spriteRenderer.sprite = pressedSprite;
        _buttonClickSound.clip = buttonPressSound;
        _buttonClickSound.Play();
    }

    public void UnpressedSprite()
    {
        _spriteRenderer.sprite = unpressedSprite;
        _buttonClickSound.clip = buttonReleaseSound;
        _buttonClickSound.Play();
    }

}
