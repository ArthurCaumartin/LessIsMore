using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent<GameObject> onTriggerEnterEvent;

    void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnterEvent.Invoke(other.gameObject);
    }
}
