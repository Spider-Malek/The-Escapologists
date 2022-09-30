using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    public Vector2 MoveInput()
    {
        return input.actions["Move"].ReadValue<Vector2>();
    }
}
