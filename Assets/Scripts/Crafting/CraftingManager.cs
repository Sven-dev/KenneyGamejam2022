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
            Recipe recipe = Recipes[_index];

            CanvasManager.Instance.CorrectAmount(CraftingStation.AmountWood() >= recipe.WoodCost, CraftingStation.AmountStone() >= recipe.StoneCost, false);
            CanvasManager.Instance.ShowResource(recipe.WoodCost > 0, recipe.StoneCost > 0, false);
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
