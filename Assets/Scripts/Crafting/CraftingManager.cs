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
    int ironNeeded = 0;

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
        if (CraftingStation != null && Recipes.Count >= _index)
        {
            if (CraftingStation.Craft(_index, woodNeeded, stoneNeeded))
            {
                Transform craftedItem = Instantiate(Recipes[_index -1].Prefab);
                craftedItem.position = CraftingStation.DropPosition();
            }
        }
    }

    public void ShowSelected(int _index)
    {
        if (CanvasManager.Instance)
        {
            Debug.Log("show?");

            if (Recipes.Count >= _index)
            {
                Recipe recipe = Recipes[_index - 1];

                woodNeeded = recipe.WoodCost;
                stoneNeeded = recipe.StoneCost;

                CanvasManager.Instance.CorrectAmount(CraftingStation.AmountWood() >= woodNeeded, CraftingStation.AmountStone() >= stoneNeeded, false);
                CanvasManager.Instance.ShowResource(woodNeeded, stoneNeeded, ironNeeded);
                CanvasManager.Instance.SetCrafting(_index);
            }
        }
    }

    public string GetRecipeName(int _index)
    {
        if (Recipes.Count >= _index)
        {
            return Recipes[_index - 1].Name;
        }
        else
        {
            return "Invalid";
        }
    }
    public Recipe GetRecipe(int _index)
    {
        if (Recipes.Count >= _index)
        {
            return Recipes[_index];
        }
        else
        {
            return null;
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
