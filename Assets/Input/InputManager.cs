using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Input Input;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Input = new Input();
    }

    private void OnEnable()
    {
        Input.Playercontrols.Enable();
    }

    private void OnDisable()
    {
        Input.Playercontrols.Disable();
    }
}
