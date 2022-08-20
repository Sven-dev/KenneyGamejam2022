using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : MonoBehaviour
{
    [SerializeField] private Transform CarryPivot;
    [SerializeField] private Transform DropPivot;

    [SerializeField] private Animator anim;

    private bool Carrying = false;
    [SerializeField] private List<Transform> Carryables = new List<Transform>();
    private Transform CarriedItem;

    private void Awake()
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
        Carrying = true;
        item.GetComponent<Collider>().enabled = false;

        CraftingStation CS = item.GetComponentInParent<CraftingStation>();
        if (CS)
        {
            if (item.CompareTag("Wood"))
            {
                CS.RemoveWood(item);
            }
            else if(item.CompareTag("Stone"))
            {
                CS.RemoveStone(item);
            }
            else if (item.CompareTag("Iron"))
            {
                CS.RemoveStone(item);
            }
        }

        if (item.CompareTag("Shovel"))
        {
            GraveDigger.Instance.DigAllowed = true;
        }

        item.parent = CarryPivot;
        item.localPosition = Vector3.zero;
        item.localRotation = Quaternion.Euler(Vector3.zero);

        CarriedItem = item;

        if (CarriedItem != null)
        {
            anim.SetBool("Holding", true);
        }
    }

    private void Drop()
    {
        Carrying = false;
        if (CarriedItem.CompareTag("Shovel"))
        {
            GraveDigger.Instance.DigAllowed = false;
        }

        CarriedItem.position = new Vector3(
            Mathf.RoundToInt(DropPivot.position.x),
            Mathf.RoundToInt(DropPivot.position.y),
            Mathf.RoundToInt(DropPivot.position.z));
        CarriedItem.parent = null;

        Vector3 rotation = transform.eulerAngles;
        rotation.x = Mathf.RoundToInt(rotation.x / 90) * 90;
        rotation.y = Mathf.RoundToInt(rotation.y / 90) * 90;
        rotation.z = Mathf.RoundToInt(rotation.z / 90) * 90;
        CarriedItem.eulerAngles = rotation;

        
        CarriedItem.GetComponent<Collider>().enabled = true;
        CarriedItem = null;
        anim.SetBool("Holding", false);
    }
}