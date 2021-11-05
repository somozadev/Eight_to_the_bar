using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Transform rotation;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 movement_input;
    private Vector2 movement_input_raw;
    [Space]
    [SerializeField] float speed;
    [SerializeField] bool isMoving;
    [Space]
    [SerializeField] bool isRunning;


    void FixedUpdate()
    {
        if (isMoving)
        {
            MovePlayer();
            RotatePlayer();
            RunPlayer();
        }

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
    public void RotateToLookAt(Transform looker)
    {
        Vector3 thisPos = new Vector3(rotation.position.x, 0, rotation.position.z);
        Vector3 otherPos = new Vector3(looker.position.x, 0, looker.position.z);
        rotation.rotation = Quaternion.LookRotation(-(thisPos - otherPos));
    }
    private void RunPlayer()
    {
        if (isRunning)
            speed = 8f;
        else
            speed = 6f;
    }
    private void OnMovement(InputValue value)
    {
        movement_input_raw = value.Get<Vector2>();
        isMoving = movement_input_raw == Vector2.zero ? false : true;
        movement_input = new Vector3(movement_input_raw.x, 0f, movement_input_raw.y);
    }
    private void OnRunning(InputValue value)
    {
        isRunning = System.Convert.ToBoolean(value.Get<float>());
    }


}
