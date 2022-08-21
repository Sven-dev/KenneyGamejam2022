using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementLabel : MonoBehaviour
{
    private Vector3 DefaultPosition;

    [SerializeField] private Collider Collider;
    [SerializeReference] private SpriteRenderer RequirementBorder;
    [SerializeReference] private SpriteRenderer RequirementLbl;

    private void Start()
    {
        DefaultPosition = transform.position;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);

        if (Mathf.Abs(transform.position.y - DefaultPosition.y) > 0.1f)
        {
            Collider.enabled = false;

            RequirementLbl.enabled = false;
            RequirementBorder.enabled = false;
        }
        else
        {
            Collider.enabled = true;

            RequirementLbl.enabled = true;
            RequirementBorder.enabled = true;
        }
    }
}