using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform rotation;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 movement_input;
    private Vector2 movement_input_raw;
    [Space]
   [SerializeField] bool isMoving;
    [Space]
    [SerializeField] float speed;
    [SerializeField] float jump_force;


    void FixedUpdate()
    {
        if (isMoving){
            MovePlayer();
            RotatePlayer();}

    }
    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(movement_input) * speed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
    }
    private void RotatePlayer()
    {
        rotation.transform.rotation = Quaternion.LookRotation(rb.velocity);
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
