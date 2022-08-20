using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionUI : MonoBehaviour
{
    [SerializeField] Image BorderColour = null;
    [SerializeField] Image Icon = null;


    public void ChangeColour(Color _newColour)
    {
        BorderColour.color = _newColour;
       // Icon.color = _newColour;
    }
}
