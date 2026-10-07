using System;
using System.Collections;
using Interfaces;
using UnityEngine;

public class TrashVacuum : MonoBehaviour
{
    [SerializeField] private HungerManager hungerManager;
    
    private GameObject _gameObject;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            _gameObject = rb.gameObject;
            rb.linearVelocityY += 20f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_gameObject != null)
        {
            StartCoroutine(Wait(_gameObject));
        }
    }

    IEnumerator Wait(GameObject go)
    {
        yield return new WaitForSeconds(.5f);
        if (go.transform.localPosition.y > 20f && go.TryGetComponent<GenericFood>(out GenericFood gf))
        {
            //hungerManager.IncreaseHunger(gf.GetCurrentHungerValue());
            Destroy(go);
        }
    }

}
