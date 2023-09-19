using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;

public class MenuElement : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite elementSprite;
    [SerializeField] Sprite brokenElementSprite;
    [Header("Hit Animation :")]
    [SerializeField] float animationDuration;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] Transform animationTargetPosition;
    [SerializeField] UnityEvent onHitEvent;
    bool hasBennHit = false;
    Vector3 startPosition;



    void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileDestroy rockDestroy = other.GetComponent<ProjectileDestroy>();
        if(rockDestroy)
        {
            spriteRenderer.sprite = brokenElementSprite;
            MenuManager.instance.PlayMenuElementAnimation();
            hasBennHit = true;
        }
    }

    public void RemoveAnimation()
    {
        transform.DOMove(animationTargetPosition.position, animationDuration)
        .SetEase(animationCurve)
        .OnComplete(() =>
        {
            if(hasBennHit)
                onHitEvent.Invoke();    
            hasBennHit = false;
        });
    }

    public void ResetElement()
    {
        if(startPosition == Vector3.zero)
            startPosition = transform.position;
            
        spriteRenderer.sprite = elementSprite;
        transform.position = startPosition;
    }
}
