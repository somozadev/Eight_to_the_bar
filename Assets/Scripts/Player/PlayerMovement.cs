using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 movement_input;
    private Vector2 movement_input_raw;
    [SerializeField] Vector2 mouse_input;
    [Space]
    [SerializeField] bool isMoving;
    [Space]
    [SerializeField] float speed;
    [SerializeField] float sensitivity;
    [SerializeField] float jump_force;


    void FixedUpdate()
    {
        if (isMoving)
            MovePlayer();
    }
    private void MovePlayer()
    {
        // if (movement_input_raw.magnitude > 0.2f)
        // {ASASASASASASASASASAS
            Vector3 moveVector = transform.TransformDirection(movement_input) * speed;
            rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
    }
    private void Jump()
    {

        rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
    }

    private void OnMovement(InputValue value)
    {
        movement_input_raw = value.Get<Vector2>();
        isMoving = movement_input_raw == Vector2.zero ? false : true;
        movement_input = new Vector3(movement_input_raw.x, 0f, movement_input_raw.y);
    }
}
