using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControll : MonoBehaviour
{
    public Text EasyStar, MediumStar, HardStar;

    void Start()
    {
        EasyStar.text = ": " + Preferences.EasyValueStarRead();

        MediumStar.text = ": " + Preferences.MediumValueStarRead();

        HardStar.text = ": " + Preferences.HardValueStarRead();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
