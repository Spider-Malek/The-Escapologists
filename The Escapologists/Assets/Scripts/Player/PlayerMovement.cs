using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private InputController input;
    private Vector2 MoveDir;
    [SerializeField]
    private float Speed = 10;
    [SerializeField]
    private string MoveAnimationX = "MoveX";
	[SerializeField]
	private string MoveAnimationY = "MoveY";


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputController>();
        TryGetComponent<Animator>(out anim);
    }

    private void Update()
    {
        MoveDir = input.MoveInput();
        anim?.SetFloat(MoveAnimationX, MoveDir.x);
        anim?.SetFloat(MoveAnimationY, MoveDir.y);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveDir * Speed * Time.deltaTime);
    }
}
