using System;
using NUnit.Framework.Constraints;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/Food")]
public class Food : ScriptableObject, IButton
{
    public string foodName;
    public Sprite uneatenSprite;
    public Sprite eatenSprite;
    public GameObject prefab;

    private bool eaten = false;
    
    public void OnPress()
    {
        if(!eaten)
            Debug.Log("Eated");
    }
}
