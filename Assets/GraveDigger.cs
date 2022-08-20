using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveDigger : MonoBehaviour
{
    public static GraveDigger Instance;

    public bool DigAllowed = false;
    [Space]
    [SerializeField] Transform GravePivotStart;
    [SerializeField] Transform GravePivotEnd;
    [SerializeField] Transform GravePrefab;
    [Space]
    [SerializeField] private Animator Animator;
    [SerializeField] private PlayerMovement Movement;

    private void Awake()
    {
        Instance = this;
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
        Transform grave = Instantiate(GravePrefab, GravePivotStart.position, transform.rotation);

        grave.position = new Vector3(Mathf.Round(GravePivotStart.position.x), GravePivotStart.position.y, Mathf.Round(GravePivotStart.position.z));

        Vector3 rotation = grave.eulerAngles;
        rotation.x = Mathf.Round(rotation.x / 90) * 90;
        rotation.y = -Mathf.Round(rotation.y / 90) * 90;
        rotation.z = Mathf.Round(rotation.z / 90) * 90;
        grave.eulerAngles = rotation;

        yield return new WaitForSeconds(0.25f);

        float progress = 0;
        while (progress < 1)
        {
            progress = Mathf.Clamp01(progress + Time.deltaTime / 3.5f);
            grave.position = Vector3.Lerp(GravePivotStart.position, GravePivotEnd.position, progress);

            yield return null;
        }

        yield return new WaitForSeconds(0.25f);
        Movement.MovingAllowed = true;
    }
}