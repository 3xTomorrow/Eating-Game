using System;
using Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerInputManager : MonoBehaviour
{
    [SerializeField] private EffectsManager effectsManager;
    
    private Camera _cam;
    private const String _BUTTON_TAG = "Button";
    
    
    private void Start()
    {
        _cam = Camera.main;
    }
    
    private void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Collider2D ray = Physics2D.OverlapPoint(mousePos);
            if (ray is not null)
            {
                if (ray.CompareTag(_BUTTON_TAG))
                {
                    ray.GetComponent<IPressable>().OnPress();
                    effectsManager.ClickEffect(mousePos);
                    if (ray.TryGetComponent<Button>(out Button pressable))
                    {
                        pressable.PressedSprite();
                    }
                }
            }
        }

        if (Mouse.current.leftButton.isPressed)
        {
            Collider2D ray = Physics2D.OverlapPoint(mousePos);
            if (ray is not null)
            {
                if (ray.TryGetComponent<IDraggable>(out IDraggable draggable))
                {
                    draggable.Dragged(mousePos);
                }
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Collider2D ray = Physics2D.OverlapPoint(mousePos);
            if (ray is not null)
            {
                if(ray.TryGetComponent<Button>(out Button pressable))
                {
                    pressable.UnpressedSprite();
                }
            }
            
        }
    }
}  
