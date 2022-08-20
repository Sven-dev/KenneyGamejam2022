using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform ObjToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = ObjToFollow.position;
    }
}