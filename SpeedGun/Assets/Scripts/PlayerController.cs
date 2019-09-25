using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float Speed;
    public float JumpHeight;

    public bool isGrounded = true;
    private Rigidbody rb;
    private Vector3 movement;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = Vector3.zero;
        // Dont detect Inputs if no key is being pressed
        if (!Input.anyKey) return;
        
        // WASD
        if(Input.GetKey(KeyConfig.Forward)) movement += rb.transform.forward;
        if(Input.GetKey(KeyConfig.Back)) movement -= rb.transform.forward;
        if(Input.GetKey(KeyConfig.Right)) movement += rb.transform.right;
        if(Input.GetKey(KeyConfig.Left)) movement -= rb.transform.right;

        // JUMP
        if (Input.GetKeyDown(KeyConfig.Jump))
            if (CheckIsOnGround())
                Jump();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (Vector3.Normalize(movement) * Speed * Time.fixedDeltaTime));
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
        rb.AddForce(Vector3.Normalize(movement) * Speed / 2.0f, ForceMode.Impulse);
    }

    private bool CheckIsOnGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, transform.localScale.y * 1.1f))
            return true;
        else
            return false;
    }
}
