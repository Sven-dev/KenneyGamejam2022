using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    [SerializeField]
    int index = 0;
    
    public void ShowSelected()
    {

        if (CraftingManager.Instance)
        {
            CraftingManager.Instance.ShowSelected(index);
        }
    }
    public void Selected()
    {
        if (CraftingManager.Instance)
        {
            CraftingManager.Instance.Craft(index);
        }
    }

    

}
