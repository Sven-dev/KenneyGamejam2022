using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    [SerializeField] private Transform WoodPivot;
    [SerializeField] private Transform StonePivot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player was here");
            if (CanvasManager.Instance)
            {
                Debug.Log("canvas exists");
                CanvasManager.Instance.ShowCraftingPanel(true);
            }
        }

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
        if (other.CompareTag("Player"))
        {
            if (CanvasManager.Instance)
            {
                CanvasManager.Instance.ShowCraftingPanel(false);
            }
        }

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
    }
    public void RemoveWood(Transform wood)
    {
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
    }
    public void RemoveStone(Transform stone)
    {
        foreach (Transform stackedStone in StonePivot)
        {
            stackedStone.Translate(Vector3.down * 0.25f);
        }
    }


    public void Craft(int _wood, int _stone)
    {
        if (StonePivot.childCount >= _stone && WoodPivot.childCount >= _wood)
        {

        }
    }
}