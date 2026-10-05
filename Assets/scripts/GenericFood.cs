using System;
using UnityEngine;
using System.Collections.Generic;
using Interfaces;

public class GenericFood : MonoBehaviour, IPressable, IDraggable
{
    [SerializeField] private List<Food> foods;
    [SerializeField] private AudioClip eatenSound;

    [SerializeField, Min(0)] private float dragSpeed = 5f;
    
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
        }
    }

    public void OnRelease()
    {
        if (HasFood)
        {
            _eaten = true;
        }
    }
    
    public void Dragged(Vector2 position)
    {
        if (_eaten)
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            transform.localPosition = new Vector2(Mathf.Lerp(transform.localPosition.x, position.x, Time.deltaTime * dragSpeed), Mathf.Lerp(transform.localPosition.y, position.y, Time.deltaTime * dragSpeed));    
        }
        
    }

    public void OnDestroy()
    {
        HasFood = false;
        _eaten = false;
    }
}
