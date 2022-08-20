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
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.ExitGame();
        }
    }
}
