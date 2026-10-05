using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonClickEffect;

    public void ClickEffect(Vector2 pos)
    {
        Instantiate(buttonClickEffect, pos, new Quaternion(0f,0f,0f,0f));
    }

}
