using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.LoadLevel(2,Transition.Crossfade);
        }
    }

    public void EndGame()
    {
        LevelManager.ExitGame();
    }

    bool openHowTo = false;
    public void SwitchHowTo()
    {
        if (!openHowTo)
        {
            if (openOption) SwitchOptions();
            if (openCredits) SwitchCredits();

        }


    }

    bool openOption = false;
    public void SwitchOptions()
    {
        if (!openOption)
        {
            if (openHowTo) SwitchHowTo();
            if (openCredits) SwitchCredits();

        }


    }

    bool openCredits = false;
    public void SwitchCredits()
    {
        if (!openCredits)
        {
            if (openHowTo) SwitchHowTo();
            if (openOption) SwitchOptions();

        }


    }

}
