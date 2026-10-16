using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class TrashVacuum : MonoBehaviour
{
    [Header("Audio Clips")] 
    [SerializeField] private List<AudioClip> popSounds;
    [FormerlySerializedAs("suctionContinue")] [SerializeField] private AudioClip suction;

    public static event EventHandler OnLastFoodDestroyed;
    
    private AudioSource _audioSource;
    private GameObject _gameObject;
    private System.Random _random;

    private bool _isFull;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _random = new System.Random();
    }

    private void Start()
    {
        HungerManager.OnFullnessReached += HungerManagerOnFullnessReached;
    }

    private void HungerManagerOnFullnessReached(object sender, EventArgs e)
    {
        _isFull = true;
        HungerManager.OnFullnessReached -= HungerManagerOnFullnessReached;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource.Stop(); //Stop any sounds if they were playing
        _audioSource.clip = suction;
        _audioSource.loop = true;
        _audioSource.Play();
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
        _audioSource.Stop();
        _audioSource.loop = false;
        _audioSource.clip = null;
        if (_gameObject != null)
        {
            if (_isFull)
            {
                OnLastFoodDestroyed?.Invoke(this, EventArgs.Empty);
            }
            StartCoroutine(Wait(_gameObject));
        }
    }

    IEnumerator Wait(GameObject go)
    {
        yield return new WaitForSeconds(.25f);
        if (Mathf.Abs(go.transform.localPosition.y) > 5f && go.TryGetComponent<GenericFood>(out GenericFood gf))
        {
            int randomIndex = _random.Next(0, popSounds.Count);
            _audioSource.PlayOneShot(popSounds[randomIndex]);
            Destroy(go);
        }
    }

}
