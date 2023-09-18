using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{
    [SerializeField] float shootMultiplier;
    Rigidbody2D rockRigidbody;
    Vector2 chargeStart;
    Vector2 chargeEnd;
    bool shoot;
    Vector2 mousePosition;

    void FixedUpdate()
    {
        if(shoot)
        {
            shoot = false;
            rockRigidbody.velocity = Vector2.zero;

            Vector2 shootDirection = (chargeEnd - chargeStart).normalized;
            float shootDistance = Vector2.Distance(chargeEnd, chargeStart);
            rockRigidbody.AddForce(shootDirection * shootDistance * shootMultiplier, ForceMode2D.Impulse);
            rockRigidbody.angularVelocity += Random.Range(-60f, 60f) * shootDistance;
        }
    }

    public void SetCurrentRock(GameObject toSet)
    {
        rockRigidbody = toSet.GetComponent<Rigidbody2D>();
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
            rockRigidbody.isKinematic = false;
            shoot = true;
        }
    }

    public void OnMouseMouve(InputAction.CallbackContext callback)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(callback.ReadValue<Vector2>());
    }
}
