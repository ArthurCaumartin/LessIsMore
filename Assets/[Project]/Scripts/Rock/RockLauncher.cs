using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{
    [SerializeField] float shootForceMultiplier;
    Rigidbody2D rockRigidbody;
    Vector2 chargeStart;
    Vector2 chargeEnd;
    bool shoot;
    bool currentRockShot = false;
    Vector2 mousePosition;

    void FixedUpdate()
    {
        if(shoot && !currentRockShot)
        {
            shoot = false;
            currentRockShot = true;
            rockRigidbody.GetComponent<ProjectileLife>().StartLife();
            rockRigidbody.isKinematic = false;

            Vector2 shootDirection = (chargeEnd - chargeStart).normalized;
            float shootDistance = Vector2.Distance(chargeEnd, chargeStart);
            rockRigidbody.AddForce(shootDirection * shootDistance * shootForceMultiplier, ForceMode2D.Impulse);
            rockRigidbody.angularVelocity += Random.Range(-60f, 60f) * shootDistance;
        }
        else
        {
            shoot = false;
        }
    }

    public void SetCurrentRock(GameObject toSet)
    {
        rockRigidbody = toSet.GetComponent<Rigidbody2D>();
        currentRockShot = false;
    }

    public void OnClic(InputAction.CallbackContext callback)
    {
        if(callback.performed)
        {
            chargeStart = mousePosition;
        }
        else if(callback.canceled)
        {
            chargeEnd = mousePosition;
            shoot = true;
        }
    }

    public void OnMouseMouve(InputAction.CallbackContext callback)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(callback.ReadValue<Vector2>());
    }
}
