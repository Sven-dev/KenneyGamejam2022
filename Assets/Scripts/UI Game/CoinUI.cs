using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField]
    Text AmountText = null;


    // Start is called before the first frame update
    void Start()
    {
        AmountText.text = "0";
    }

    internal void UpdateAmount(int _amount)
    {
        AmountText.text = "" + _amount;
    }
}
