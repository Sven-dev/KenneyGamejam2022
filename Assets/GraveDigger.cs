using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveDigger : MonoBehaviour
{
    public static GraveDigger Instance;

    public bool DigAllowed = false;
    [Space]
    [SerializeField] Transform GravePivot;
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
            AudioManager.Instance.Play("Dig", 1f);
        }
    }

    private IEnumerator _SpawnGrave()
    {
        Animator.SetTrigger("DiggyDiggyHole");
        Movement.MovingAllowed = false;
        Transform grave = Instantiate(GravePrefab, GravePivot.position, transform.rotation);

        grave.position = new Vector3(
            Mathf.RoundToInt(GravePivot.position.x),
            GravePivot.position.y,
            Mathf.RoundToInt(GravePivot.position.z));

        Vector3 rotation = grave.eulerAngles;
        rotation.x = Mathf.RoundToInt(rotation.x / 90) * 90;
        rotation.y = -Mathf.RoundToInt(rotation.y / 90) * 90;
        rotation.z = Mathf.RoundToInt(rotation.z / 90) * 90;
        grave.eulerAngles = rotation;

        yield return new WaitForSeconds(0.25f);

        Vector3 graveStart = grave.position;
        Vector3 graveEnd = grave.position + Vector3.up * 0.5f;

        float progress = 0;
        while (progress < 1)
        {
            progress = Mathf.Clamp01(progress + Time.deltaTime / 3.5f);
            grave.position = Vector3.Lerp(graveStart, graveEnd, progress);

            yield return null;
        }

        yield return new WaitForSeconds(0.25f);
        Movement.MovingAllowed = true;
    }
}