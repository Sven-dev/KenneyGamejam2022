using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [Space]
    [SerializeField] private Camera Cam;
    [SerializeField] private Rigidbody Rigidbody;

    private Vector3 Movement = Vector3.zero;

    private void OnEnable()
    {
        InputManager.Input.Playercontrols.Enable();
    }

    private void OnDisable()
    {
        InputManager.Input.Playercontrols.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = InputManager.Input.Playercontrols.Move.ReadValue<Vector2>();
        CalculateMovement(moveInput);
    }

    private void FixedUpdate()
    {
        //Move
        Rigidbody.position += Movement * Speed * Time.deltaTime;
    }

    private void CalculateMovement(Vector2 movement)
    {
        Vector3 towards = transform.position - Cam.transform.position;
        towards.y = 0.0f;
        towards.Normalize();

        Vector3 right = Vector3.Cross(Vector3.up, towards);
        right.y = 0.0f;
        right.Normalize();

        Movement = towards * movement.y + right * movement.x;              
    }
}