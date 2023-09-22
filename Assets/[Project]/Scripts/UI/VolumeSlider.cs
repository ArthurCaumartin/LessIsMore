using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Transform currentVolume;
    [SerializeField] Transform point0;
    [SerializeField] Transform point1;

    void OnTriggerEnter2D(Collider2D other)
    {
        SetVolume(other.transform);
    }

    public void SetVolume(Transform hitTransform)
    {
        float point0x = point0.localPosition.x;
        float point1x = point1.localPosition.y;
        float inversLerpValue = Mathf.InverseLerp(point0x, point1x, hitTransform.position.x);

        // Vector3

        print("Volume Slider hit : Value = " + inversLerpValue);
    }
}
