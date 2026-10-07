using System;
using NUnit.Framework.Constraints;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/Food")]
public class Food : ScriptableObject
{
    public string foodName;
    public Sprite uneatenSprite;
    public Sprite eatenSprite;
    public int hungerValue;
}
