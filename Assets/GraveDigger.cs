using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveDigger : MonoBehaviour
{
    public bool DigAllowed = false;
    [Space]
    [SerializeField] Transform GravePivotStart;
    [SerializeField] Transform GravePivotEnd;
    [SerializeField] Transform GravePrefab;
    [Space]
    [SerializeField] private Animator Animator;
    [SerializeField] private PlayerMovement Movement;

    private void OnEnable()
    {
        InputManager.Input.Playercontrols.Dig.started += DigGrave;
    }

    private void DigGrave(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (DigAllowed)
        {
            StartCoroutine(_SpawnGrave());
        }
    }

    private IEnumerator _SpawnGrave()
    {
        Animator.SetTrigger("DiggyDiggyHole");
        Movement.MovingAllowed = false;
        Transform Grave = Instantiate(GravePrefab, GravePivotStart.position, transform.rotation);

        yield return new WaitForSeconds(1f);

        float progress = 0;
        while (progress <= 1)
        {
            progress = Mathf.Clamp01(progress + Time.deltaTime);
            Grave.position = Vector3.Lerp(GravePivotStart.position, GravePivotEnd.position, progress);
        }

        yield return new WaitForSeconds(1f);
        Movement.MovingAllowed = true;
    }
}