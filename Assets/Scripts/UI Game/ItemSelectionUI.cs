using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionUI : MonoBehaviour
{
    [SerializeField] Image BorderColour = null;
    [SerializeField] Image Icon = null;
    [SerializeField] Text Number = null;


    public void ChangeColour(Color _newColour)
    {
        BorderColour.color = _newColour;
        // Icon.color = _newColour;
    }
    public void ChangeAmount(int _amount)
    {
        Number.text = "x" + _amount;
    }
}
