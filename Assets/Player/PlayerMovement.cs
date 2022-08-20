using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public bool MovingAllowed = true;
    [Space]
    [SerializeField] private float Speed = 1;
    [Space]
    [SerializeField] private Camera Cam;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private Animator anim;

    private Vector3 Movement = Vector3.zero;

    private void Update()
    {
        if (MovingAllowed)
        {
            Vector2 moveInput = InputManager.Input.Playercontrols.Move.ReadValue<Vector2>();
            CalculateMovement(moveInput);
        }
    }

    private void FixedUpdate()
    {
        //Move
        Rigidbody.position += Movement * Speed * Time.deltaTime;
        anim.SetFloat("Speed", Movement.sqrMagnitude);

        //Rotate
        LerpLookAt();
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

    private void LerpLookAt()
    {
        if (Movement.sqrMagnitude > 0)
        {
            Quaternion lookAt = Quaternion.LookRotation(Movement, Vector3.up);

            float fLookTo = transform.rotation.eulerAngles.y;
            float fLookAt = lookAt.eulerAngles.y;
            float fNeed = fLookAt - fLookTo;

            if (fNeed > 180.0f)
            {
                fNeed -= 360;
            }

            if (Mathf.Abs(fNeed) > 2.0f)
            {
                Rigidbody.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * 15.0f);
            }
            else
            {
                Rigidbody.rotation = Rigidbody.rotation;
            }
        }
    }
}