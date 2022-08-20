using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : MonoBehaviour
{
    [SerializeField] private Transform CarryPivot;
    [SerializeField] private Transform DropPivot;

    private bool Carrying = true;
    [SerializeField] private List<Transform> Carryables = new List<Transform>();
    private Transform CarriedItem;

    private void Start()
    {
        InputManager.Input.Playercontrols.Carry.started += CalculatePickupDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Carryables.Contains(other.transform))
        {
            Carryables.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Carryables.Remove(other.transform);
    }

    private void CalculatePickupDistance(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Carrying = !Carrying;       
        if (!Carrying && Carryables.Count > 0)
        {
            //Calculate which item needs to be picked up
            //For now we're doing it by checking the closest object, but it should probably also look at what object the player is looking at
            Transform closestItem = null;
            float closestDistance = Mathf.Infinity;
            foreach(Transform item in Carryables)
            {
                float distance = Vector3.Distance(transform.position, item.position);
                if (distance <= closestDistance)
                {
                    //There's something closer
                    closestDistance = distance;
                    closestItem = item;
                }
            }

            PickUp(closestItem);
            print("Picked up item");
        }
        else
        {
            Drop();
            print("Dropped item");
        }      
    }

    private void PickUp(Transform item)
    {
        item.parent = CarryPivot;
        item.localPosition = Vector3.zero;
        item.localRotation = Quaternion.Euler(Vector3.zero);

        CarriedItem = item;
    }

    private void Drop()
    {
        CarriedItem.position = DropPivot.position;
        CarriedItem.parent = null;
        CarriedItem.localRotation = Quaternion.Euler(Vector3.zero);
    }
}