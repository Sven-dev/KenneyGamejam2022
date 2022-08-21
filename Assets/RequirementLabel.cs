using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementLabel : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        transform.LookAt(Camera.main.transform);
    }
}