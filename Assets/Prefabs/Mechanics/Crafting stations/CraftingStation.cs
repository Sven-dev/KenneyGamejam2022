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
            if (CanvasManager.Instance)
            {
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

    public int AmountWood()
    {
        return WoodPivot.childCount;
    }
    public int AmountStone()
    {
        return StonePivot.childCount;
    }

    public bool Craft(int index, int _wood, int _stone)
    {
        if (StonePivot.childCount >= _stone && WoodPivot.childCount >= _wood)
        {
            Transform removal = null;
            for (int w = 0; w < _wood; w++)
            {
                removal = WoodPivot.GetChild(0);
                removal.parent = null;
                removal.position = Vector3.down * 5.0f;
                removal.gameObject.SetActive(false);
            }

            for (int s = 0; s < _stone; s++)
            {
                removal = StonePivot.GetChild(0);
                removal.parent = null;
                removal.position = Vector3.down * 5.0f;
                removal.gameObject.SetActive(false);
            }


            return true;
        }
        else
        {
            return false;
        }
    }
}