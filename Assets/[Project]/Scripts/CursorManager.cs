using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Transform cursorTr;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void OnMouseMove(InputAction.CallbackContext callback)
    {
        Vector2 callBackVector = callback.ReadValue<Vector2>();
    }
}
