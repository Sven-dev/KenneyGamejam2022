using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementLabel : MonoBehaviour
{
    private Vector3 DefaultPosition;

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
            gameObject.SetActive(false);
        }
    }
}