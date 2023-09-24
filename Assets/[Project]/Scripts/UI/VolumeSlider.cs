using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Unity.Mathematics;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Transform point0;
    [SerializeField] Transform point1;
    [SerializeField] UnityEvent<float> onTriggerEnterEvents;

    void OnTriggerEnter2D(Collider2D other)
    {
        float value = VolumeToSet(other.transform);
        print(value);
        onTriggerEnterEvents.Invoke(value);
    }

    float VolumeToSet(Transform hitTransform)
    {
        float point0x = point0.position.x;
        float point1x = point1.position.x;
        float inversLerpValue = Mathf.InverseLerp(point0x, point1x, hitTransform.position.x);
        return inversLerpValue;
    }
}
