using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerToolUsage : MonoBehaviour
{
    public static Tool CurrentSelectedTool = null;
    [SerializeField]
    private Tilemap tilemap;
    private Camera cam;
    private Mouse mouse;

    private void Start()
    {
        cam = Camera.main;
        mouse = Mouse.current;
    }

    public void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {

        }
    }
}
