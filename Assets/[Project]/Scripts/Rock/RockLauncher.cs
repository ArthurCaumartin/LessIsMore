using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{
    [SerializeField] float shootForceMultiplier;
    [SerializeField] float maxChargeDistance;
    Rigidbody2D projectileRigidbody;
    Vector2 chargeStart;
    Vector2 chargeEnd;
    bool shoot;
    bool currentRockShot = false;
    bool isDraging = false;
    Vector2 mousePosition;

    Vector2 shootDirection;
    float shootDistance;

    void Update()
    {
        if(isDraging)
        {
            chargeEnd = mousePosition;
            shootDirection = (chargeStart - chargeEnd).normalized;
            shootDistance = Vector2.Distance(chargeStart, chargeEnd);
            shootDistance = Mathf.Clamp(shootDistance, -50f, maxChargeDistance); 

            Debug.DrawRay(chargeStart, shootDirection * shootDistance, Color.green, 0.01f);
        }
    }

    void FixedUpdate()
    {
        if(shoot && !currentRockShot)
        {
            shoot = false;
            currentRockShot = true;
            LaunchProjectile();
        }
        else
        {
            shoot = false;
        }
    }

    void LaunchProjectile()
    {
        projectileRigidbody.GetComponent<ProjectileLife>().StartLife();
        projectileRigidbody.isKinematic = false;
        projectileRigidbody.AddForce(shootDirection * shootDistance * shootForceMultiplier, ForceMode2D.Impulse);
        projectileRigidbody.angularVelocity += Random.Range(-60f, 60f) * shootDistance;
    }

    public void SetCurrentRock(GameObject toSet)
    {
        projectileRigidbody = toSet.GetComponent<Rigidbody2D>();
        currentRockShot = false;
    }

    public void OnClic(InputAction.CallbackContext callback)
    {
        if(callback.performed)
        {
            chargeStart = mousePosition;
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
