using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TrashVacuum : MonoBehaviour
{
    [Header("Audio Clips")] 
    [SerializeField] private List<AudioClip> popSounds;
    [SerializeField] private AudioClip vacuumSound;
    
    private AudioSource _audioSource;
    private GameObject _gameObject;
    private System.Random _random;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _random = new System.Random();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //play vacuum sound here
    }
    
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
        //stop vacuum sound here
        if (_gameObject != null)
        {
            StartCoroutine(Wait(_gameObject));
        }
    }

    IEnumerator Wait(GameObject go)
    {
        yield return new WaitForSeconds(.25f);
        if (go.transform.localPosition.y > 10f && go.TryGetComponent<GenericFood>(out GenericFood gf))
        {
            int randomIndex = _random.Next(0, popSounds.Count);
            _audioSource.PlayOneShot(popSounds[randomIndex]);
            Destroy(go);
        }
    }

}
