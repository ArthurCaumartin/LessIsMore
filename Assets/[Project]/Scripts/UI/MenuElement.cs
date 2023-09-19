using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public class MenuElement : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite elementSprite;
    [SerializeField] Sprite brokenElementSprite;
    [SerializeField] UnityEvent onHitEvent;

    void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileDestroy rockDestroy = other.GetComponent<ProjectileDestroy>();
        if(rockDestroy)
        {
            spriteRenderer.sprite = brokenElementSprite;
            onHitEvent.Invoke();
        }
    }

    public void ResetElement()
    {
        spriteRenderer.sprite = elementSprite;
    }
}
