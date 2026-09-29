using System;
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
            if (ray is not null && ray.CompareTag(_BUTTON_TAG))
            {
                ray.GetComponent<IButton>().OnPress();
                effectsManager.ClickEffect(mousePos);
                if (ray.TryGetComponent<IPressable>(out IPressable pressable))
                {
                    pressable.PressedSprite();
                }
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Collider2D ray = Physics2D.OverlapPoint(mousePos);
            if (ray is not null && ray.TryGetComponent<IPressable>(out IPressable pressable))
            {
                pressable.UnpressedSprite();
            }
        }
    }
}  
