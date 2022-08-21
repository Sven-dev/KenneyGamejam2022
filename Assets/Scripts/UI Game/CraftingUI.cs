using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] Color GoodColour = Color.green;
    [SerializeField] Color BadColour = Color.red;

    [Space]
    [SerializeField] GameObject Select_Panel;
    [SerializeField] Text Selection_Text;

    [Space]
    [SerializeField] ItemSelectionUI Wood_Selection;
    [SerializeField] ItemSelectionUI Stone_Selection;
    [SerializeField] ItemSelectionUI Metal_Selection;

    [Space]
    [SerializeField] ItemSelectionUI WoodGrave_Selection;
    [SerializeField] ItemSelectionUI StoneGrave_Selection;
    [SerializeField] ItemSelectionUI Fence_Selection;
    [SerializeField] ItemSelectionUI Lantern_Selection;
    [SerializeField] ItemSelectionUI Meta_Selection;

    public void SelectCrafting(int _index)
    {
        if (_index > 0)
        {
            if (!Select_Panel.activeInHierarchy)
                Select_Panel.SetActive(true);

            string craftingType = "UNKNOWN";

            if (CraftingManager.Instance)
            {
                craftingType = CraftingManager.Instance.GetRecipeName(_index);
            }


            Selection_Text.text = craftingType;
        }
        else
        {
            Select_Panel.SetActive(false);
        }
    }

    public void UpdateResourceShowing(int _wood, int _stone, int _metal)
    {
        Wood_Selection.gameObject.SetActive(_wood > 0);
        Stone_Selection.gameObject.SetActive(_stone > 0);
        Metal_Selection.gameObject.SetActive(_metal > 0);

        Wood_Selection.ChangeAmount(_wood);
        Stone_Selection.ChangeAmount(_stone);
        Metal_Selection.ChangeAmount(_metal);
    }
    public void UpdateResourceColours(bool _wood, bool _stone, bool _metal)
    {
        Wood_Selection.ChangeColour(_wood ? GoodColour: BadColour);
        Stone_Selection.ChangeColour(_stone ? GoodColour: BadColour);
        Metal_Selection.ChangeColour(_metal ? GoodColour: BadColour);
    }

    public void UpdateCraftColours(bool _wood, bool _stone, bool _fence, bool _lantern, bool _meta)
    {
        WoodGrave_Selection.ChangeColour(_wood ? GoodColour : BadColour);
        StoneGrave_Selection.ChangeColour(_stone ? GoodColour : BadColour);
        Fence_Selection.ChangeColour(_fence ? GoodColour : BadColour);
        Lantern_Selection.ChangeColour(_lantern ? GoodColour : BadColour);
        Meta_Selection.ChangeColour(_meta ? GoodColour : BadColour);
    }
}
