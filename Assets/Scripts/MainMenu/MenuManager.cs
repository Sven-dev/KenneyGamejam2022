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
    [SerializeField] GameObject HowToPanel = null;
    public void SwitchHowTo()
    {
        if (!openHowTo)
        {
            if (openOption) SwitchOptions();
            if (openCredits) SwitchCredits();
            openHowTo = true;
        }
        else openHowTo = false;

        if (HowToPanel)
        {
            HowToPanel.SetActive(openHowTo);
        }
    }

    bool openOption = false;
    [SerializeField] GameObject OptionPanel = null;
    public void SwitchOptions()
    {
        if (!openOption)
        {
            if (openHowTo) SwitchHowTo();
            if (openCredits) SwitchCredits();
            openOption = true;
        }
        else openOption = false;

        if (OptionPanel)
        {
            OptionPanel.SetActive(openOption);
        }
    }

    bool openCredits = false;
    [SerializeField] GameObject CreditPanel = null;
    public void SwitchCredits()
    {
        if (!openCredits)
        {
            if (openHowTo) SwitchHowTo();
            if (openOption) SwitchOptions();
            openCredits = true;
        }
        else openCredits = false;

        if (CreditPanel)
        {
            CreditPanel.SetActive(openCredits);
        }

    }

    public void SliderMasterChanged(float _amount)
    {
        Debug.Log("changed Master to " + _amount);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.MasterVolume = _amount;
        }
    }
    public void SliderMusicChanged(float _amount)
    {
        Debug.Log("changed Music to " + _amount);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.MusicVolume = _amount;
        }
    }
    public void SliderSoundChanged(float _amount)
    {
        Debug.Log("changed Sound to " + _amount);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.SoundVolume = _amount;
        }
    }
    public void SliderDialogueChanged(float _amount)
    {
        Debug.Log("changed Dialogue to " + _amount);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.DialogueVolume = _amount;
        }
    }
}
