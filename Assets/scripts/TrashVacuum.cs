using System;
using Interfaces;
using UnityEngine;

public class TrashVacuum : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            print("Collided with " + other.gameObject.name);
            rb.linearVelocityY += 20f;
        }
    }
    
}
