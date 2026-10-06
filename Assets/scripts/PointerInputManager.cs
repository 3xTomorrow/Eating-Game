using System;
using Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerInputManager : MonoBehaviour
{
    [SerializeField] private EffectsManager effectsManager;
    
    private Camera _cam;

    private IDraggable _draggable;

    private bool _pressed = false;
    private Collider2D _pressedRay;
    
    
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
                if (ray.TryGetComponent<IPressable>(out IPressable pressable))
                {
                    pressable.OnPress();
                    effectsManager.ClickEffect(mousePos);
                    _pressed = true;
                    _pressedRay = ray;
                }
                if (ray.TryGetComponent<IDraggable>(out IDraggable draggable))
                {
                    _draggable = draggable;
                }
            }
        }

        if (Mouse.current.leftButton.isPressed && _draggable != null)
        {
            _draggable.Dragged(mousePos);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            _draggable = null;

            if (_pressed)
            {
                if (_pressedRay.TryGetComponent<IPressable>(out IPressable pressable))
                {
                    pressable.OnRelease();
                    _pressed = false;
                    _pressedRay = null;
                }
            }
        }
    }
}  
