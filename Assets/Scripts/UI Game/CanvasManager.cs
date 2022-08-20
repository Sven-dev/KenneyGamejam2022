using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    #region Instance
    //put instance stuff here
    private static CanvasManager _Instance;
    public static CanvasManager Instance
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


    #region UI Elements

    [SerializeField] bool TestUI = false;

    [SerializeField] CraftingUI CraftingPanel;

    private void Start()
    {
        if (TestUI)
        {
            CanCraft(true, false, true, true, false);
            CorrectAmount(true, false, true);
            ShowResource(true, true, false);

            SetCrafting(2);
        }
        else
        {
            CanCraft(false, false, false, false, false);
            CorrectAmount(false, false, false);
            ShowResource(true, true, true);

            SetCrafting(0);
        }

        ShowCraftingPanel(TestUI);
        UpdateMoneyText(69);
    }

    public void ShowCraftingPanel(bool _show)
    {
        CraftingPanel.gameObject.SetActive(_show);
    }

    public void SetCrafting(int _index)
    {
        CraftingPanel.SelectCrafting(_index);
    }

    public void CanCraft(bool _wood, bool _stone, bool _fence, bool _lantern, bool _metal)
    {
        CraftingPanel.UpdateCraftColours(_wood, _stone, _fence, _lantern, _metal);
    }

    public void CorrectAmount(bool _wood, bool _stone, bool _metal)
    {
        CraftingPanel.UpdateResourceColours(_wood, _stone, _metal);
    }
    public void ShowResource(bool _wood, bool _stone, bool _metal)
    {
        CraftingPanel.UpdateResourceShowing(_wood, _stone, _metal);
    }

    [Space]
    [SerializeField] CoinUI CoinPanel;

    public void UpdateMoneyText(int _amount)
    {
        CoinPanel.UpdateAmount(_amount);
    }

    

    #endregion


}
