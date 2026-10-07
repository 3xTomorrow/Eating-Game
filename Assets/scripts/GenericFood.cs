using System;
using UnityEngine;
using System.Collections.Generic;
using Interfaces;
using Random = System.Random;

public class GenericFood : MonoBehaviour, IPressable, IDraggable
{
    [SerializeField] private List<Food> foods;
    [SerializeField] private AudioClip eatenSound;

    [SerializeField, Min(0)] private float dragSpeed = 5f;
    
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;
    private HungerManager _hungerManager;
    private Random _random;
    private Food _currentFood;

    public static bool HasFood;
    private bool _eaten;
    private int _hungerValue;

    private void Awake()
    {
        _random = new Random();
    }
    
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        HasFood = true;
        
        int randomFoodIndex = _random.Next(0, 2);
        _currentFood = foods[randomFoodIndex];
        
        _spriteRenderer.sprite = _currentFood.uneatenSprite;
        
        _hungerValue = _currentFood.hungerValue;
    }

    public void OnPress()
    {
        if (!_eaten)
        {
            HungerManager.IncreaseHunger(_hungerValue);
            _audioSource.clip = eatenSound;
            _audioSource.Play();
            _spriteRenderer.sprite = _currentFood.eatenSprite;
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
        _hungerValue = 0;
        _currentFood = null;
        HasFood = false;
        _eaten = false;
    }
}
