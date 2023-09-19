using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] LineRenderer projectileLineRenderer;
    [SerializeField] float shootForceMultiplier;
    [SerializeField] float maxChargeDistance;
    Rigidbody2D currentProjectileRigidbody;
    Transform currentProjectileTransform;
    Vector2 chargeStartPosition;
    Vector2 chargeEndPosition;
    bool shoot;
    bool isDraging = false;
    Vector2 mousePosition;

    Vector2 shootDirection;
    float shootDistance;

    void Update()
    {
        if(isDraging)
        {
            chargeEndPosition = mousePosition;
            shootDirection = (chargeStartPosition - chargeEndPosition).normalized;
            shootDistance = Vector2.Distance(chargeStartPosition, chargeEndPosition);
            shootDistance = Mathf.Clamp(shootDistance, -50f, maxChargeDistance);

            projectileLineRenderer.SetPosition(0, chargeStartPosition);
            projectileLineRenderer.SetPosition(1, chargeEndPosition);

            Debug.DrawRay(chargeStartPosition, shootDirection * shootDistance, Color.green, 0.01f);
        }
    }

    void FixedUpdate()
    {
        if(shoot && currentProjectileRigidbody)
        {
            LaunchProjectile();
        }
        shoot = false;
    }

    public void SetCurrentProjectile(GameObject toSet)
    {
        currentProjectileTransform =  toSet.GetComponent<Transform>();
        currentProjectileRigidbody = toSet.GetComponent<Rigidbody2D>();
        projectileLineRenderer = toSet.GetComponentInChildren<LineRenderer>();
    }

    void LaunchProjectile()
    {
        currentProjectileRigidbody.GetComponent<ProjectileLife>().StartLife();
        currentProjectileRigidbody.isKinematic = false;
        // currentProjectileRigidbody.velocity = Vector2.zero;
        currentProjectileRigidbody.angularVelocity += Random.Range(-60f, 60f) * shootDistance;
        currentProjectileRigidbody.AddForce(shootDirection * shootDistance * shootForceMultiplier, ForceMode2D.Impulse);

        //! = null; to launch proj only one time
        currentProjectileRigidbody = null;
    }


    public void OnClic(InputAction.CallbackContext callback)
    {
        if(callback.performed)
        {
            chargeStartPosition = mousePosition;
            isDraging = true;
        }
        else if(callback.canceled)
        {
            isDraging = false;
            shoot = true;
        }
    }

    public void OnMouseMouve(InputAction.CallbackContext callback)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(callback.ReadValue<Vector2>());
    }
}
