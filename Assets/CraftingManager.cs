using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    CraftingStation CS = null;

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


    }
}
