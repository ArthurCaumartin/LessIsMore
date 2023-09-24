using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CameraSlowEffect : MonoBehaviour
{
    [Header("Mandatory Object :")]
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform currentProjectileTransform;
    [SerializeField] Transform projectileStartPosition;

    [Header("Parameter :")]
    [SerializeField] float distanceToStartEffect;
    float projectilePositionTime;

    [Header("Camera Animation :")]
    [SerializeField] float cameraSize;
    [SerializeField] Vector3 cameraAnimatedPosition;
    float startCameraSize;
    Vector3 startCameraAnimatedPosition;

    void Update()
    {
        Time.timeScale = 1f;

        if(currentProjectileTransform)
        { 
            projectilePositionTime = Mathf.InverseLerp(projectileStartPosition.position.x, transform.position.x, currentProjectileTransform.position.x);

            if(projectilePositionTime > 0.8f)
            {
                print("nik tou");
                float scaleTime = Mathf.InverseLerp(0.8f, 1f, projectilePositionTime);
                CameraEffect(scaleTime);
            }
        }
        else
        {
            CameraEffect(0);
        }
    }

    void CameraEffect(float time)
    {
        if(time > 0.8f)
        {
            time = 0;
        }
          
        mainCamera.orthographicSize = Mathf.Lerp(startCameraSize,  cameraSize, time);
        mainCamera.transform.position = Vector3.Lerp(startCameraAnimatedPosition, cameraAnimatedPosition, time);
        Time.timeScale = time;
    }

    public void Initialise(Transform projectileTransform)
    {
        currentProjectileTransform = projectileTransform;
    }
}

