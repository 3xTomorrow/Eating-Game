using System;
using UnityEngine;
using System.Collections.Generic;
using Interfaces;

public class GenericFood : MonoBehaviour, IPressable, IDraggable
{
    [SerializeField] private List<Food> foods;
    [SerializeField] private AudioClip eatenSound;
    
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;
    
    public static bool HasFood = false;
    private bool _eaten = false;
    
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        HasFood = true;
        _spriteRenderer.sprite = foods[0].uneatenSprite;
    }

    public void OnPress()
    {
        if (!_eaten)
        {
            _audioSource.clip = eatenSound;
            _audioSource.Play();
            _spriteRenderer.sprite = foods[0].eatenSprite;
            _eaten = true;
        }
    }
    
    public void Dragged(Vector2 position)
    {
        _rigidbody2D.linearVelocity = Vector2.zero;
        transform.localPosition = position;
    }

    /*
    public void unDragged()
    {
        
    }*/

    public void OnDestroy()
    {
        HasFood = false;
        _eaten = false;
    }
}
