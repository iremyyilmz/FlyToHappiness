using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionControl : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;

    void Start()
    {
        if(Preferences.EasyValueRead() == 1)
        {
            easyButton.interactable = false;
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }

        if(Preferences.MediumValueRead() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }

        if(Preferences.HardValueRead() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
    }

    public void Choice(string level)
    {
        switch (level)
        {
            case "easy":
                Preferences.EasyValue(1);
                Preferences.MediumValue(0);
                Preferences.HardValue(0);
                easyButton.interactable = false;
                mediumButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "medium":
                Preferences.EasyValue(0);
                Preferences.MediumValue(1);
                Preferences.HardValue(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                Preferences.EasyValue(0);
                Preferences.MediumValue(0);
                Preferences.HardValue(1);
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
                break;
            default:
                 break;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
