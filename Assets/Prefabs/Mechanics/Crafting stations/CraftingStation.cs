using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    [SerializeField] private Transform WoodPivot;
    [SerializeField] private Transform StonePivot;

    private List<Transform> WoodStack = new List<Transform>();
    private List<Transform> StoneStack = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wood")
        {
            AddWood(other.transform);
        }
        else if (other.tag == "Stone")
        {
            AddStone(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Removed object: " + other.name);

        if (other.tag == "Wood")
        {
            RemoveWood(other.transform);
        }
        else if (other.tag == "Stone")
        {
            RemoveStone(other.transform);
        }
    }

    private void AddWood(Transform wood)
    {
        wood.parent = WoodPivot;
        wood.transform.localPosition = Vector3.zero;
        wood.transform.Translate(Vector3.up * WoodPivot.childCount * 0.25f);

        WoodStack.Add(wood);
    }

    public void RemoveWood(Transform wood)
    {
        print("Removed object: " + wood.name);
        WoodStack.Remove(wood);

        foreach(Transform stackedWood in WoodPivot)
        {
            stackedWood.Translate(Vector3.down * 0.25f);
        }
    }

    private void AddStone(Transform stone)
    {
        stone.parent = StonePivot;
        stone.transform.localPosition = Vector3.zero;
        stone.transform.Translate(Vector3.up * StonePivot.childCount * 0.25f);

        StoneStack.Add(stone);
    }

    public void RemoveStone(Transform stone)
    {
        print("Removed object: " + stone.name);
        StoneStack.Remove(stone);

        foreach (Transform stackedStone in StoneStack)
        {
            print("moving stone down");
            stackedStone.Translate(Vector3.down * 0.25f);
        }
    }
}