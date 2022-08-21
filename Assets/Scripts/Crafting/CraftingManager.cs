using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] GameObject[] CraftRecipies = null;

    CraftingStation CS = null;

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
        CS = GetComponent<CraftingStation>();

    }

    public void Craft(int _index)
    {
        if (CS != null)
        {
            if (CS.Craft(_index, woodNeeded, stoneNeeded))
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
            bool wood = false, stone = false, iron = false;

            switch (_index)
            {
                case 0: wood = true; woodNeeded = 1; break;
                case 1: stone = true; stoneNeeded = 1; break;
                case 2: wood = true; woodNeeded = 2; break;
                case 3: wood = true; woodNeeded = 2; break;
                case 4: wood = true; woodNeeded = 1;
                        stone = true; stoneNeeded = 1; break;
                default: break;
            }

            CanvasManager.Instance.CorrectAmount(CS.AmountWood() >= woodNeeded, CS.AmountStone() >= stoneNeeded, false);
            CanvasManager.Instance.ShowResource(wood, stone, iron);
        }
    }

}
