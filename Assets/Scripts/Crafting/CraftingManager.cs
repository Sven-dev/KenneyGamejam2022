using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] private List<Recipe> Recipes;
    [Space]
    [SerializeField] private CraftingStation CraftingStation;
    
    int woodNeeded = 0;
    int stoneNeeded = 0;

    #region Instance
    //put instance stuff here
    private static CraftingManager _Instance;
    public static CraftingManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                Debug.LogError("Instance for GameManager is NULL");
            }

            return _Instance;
        }
    }

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    private void Start()
    {
        CraftingStation = GetComponent<CraftingStation>();

    }

    public void Craft(int _index)
    {
        if (CraftingStation != null)
        {
            if (CraftingStation.Craft(_index, woodNeeded, stoneNeeded))
            {
                //Summon item here
                Debug.Log("it works?");

            }
        }
    }

    public void ShowSelected(int _index)
    {
        if (CanvasManager.Instance)
        {
            Debug.Log("show?");

            switch (_index)
            {
                case 1: woodNeeded = 1; break;
                case 2: stoneNeeded = 1; break;
                case 3: woodNeeded = 2; break;
                case 4: woodNeeded = 2; break;
                case 5: woodNeeded = 2;
                        stoneNeeded = 2; break;
                default: break;
            }

            //CanvasManager.Instance.CorrectAmount(CS.AmountWood() >= woodNeeded, CS.AmountStone() >= stoneNeeded, false);
            //CanvasManager.Instance.ShowResource(woodNeeded, stoneNeeded, ironNeeded);
            CanvasManager.Instance.SetCrafting(_index);
        }
    }

}

[System.Serializable]
public class Recipe
{
    public string Name;
    [Space]
    public int WoodCost = 0;
    public int StoneCost = 0;
    [Space]
    public Transform Prefab;
}
