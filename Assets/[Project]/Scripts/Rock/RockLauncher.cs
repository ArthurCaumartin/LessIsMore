using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{
    [SerializeField] float shootMultiplier;
    [SerializeField] Rigidbody2D ballRigidbody;
    Vector2 chargeStart;
    Vector2 chargeEnd;
    bool shoot;

    void FixedUpdate()
    {
        if(shoot)
        {
            shoot = false;
            ballRigidbody.velocity = Vector2.zero;

            Vector2 shootDirection = (chargeEnd - chargeStart).normalized;
            float shootDistance = Vector2.Distance(chargeEnd, chargeStart);
            ballRigidbody.AddForce(shootDirection * shootDistance * shootMultiplier, ForceMode2D.Impulse);
            ballRigidbody.angularVelocity += Random.Range(-60f, 60f) * shootDistance;
        }
    }

    public void OnClic(InputAction.CallbackContext callback)
    {
        if(callback.performed)
        {
            // chargeStart = InputManager.instance.worldMousePosition;
        }
        else if(callback.canceled)
        {
            // chargeEnd = InputManager.instance.worldMousePosition;
            shoot = true;
        }
    }
}
