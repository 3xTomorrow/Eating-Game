using System;
using UnityEditor;
using UnityEngine;

public abstract class Button : MonoBehaviour, IPressable
{  
    [SerializeField] private Sprite unpressedSprite;
    [SerializeField] private Sprite pressedSprite;

    [SerializeField] private AudioClip buttonPressSound;
    [SerializeField] private AudioClip buttonReleaseSound;
    
    private AudioSource _buttonClickSound;
    private SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _buttonClickSound = GetComponent<AudioSource>();
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

    public abstract void OnPress();
}