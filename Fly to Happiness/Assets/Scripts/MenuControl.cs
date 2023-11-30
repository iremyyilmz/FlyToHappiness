using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcon = default;

    [SerializeField]
    Button musicButton = default;

    void Start()
    {
        if(Preferences.Register() == false)
        {
            Preferences.EasyValue(1);
        }

        if(Preferences.MusicRegister() == false)
        {
            Preferences.MusicOnValue(1);
        }

        MuzikAyarlari();
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Game");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Options");
    }

    public void Muzik()
    {
        if (Preferences.MusicOnValueRead() == 1)
        {
            Preferences.MusicOnValue(0);
            MusicControl.instance.MusicOn(true);
            musicButton.image.sprite = musicIcon[0];
        }
        else
        {
            Preferences.MusicOnValue(1);
            MusicControl.instance.MusicOn(false);
            musicButton.image.sprite = musicIcon[1];
        }
    }

    void MuzikAyarlari()
    {
        if(Preferences.MusicOnValueRead() == 1)
        {
            musicButton.image.sprite = musicIcon[1];
            MusicControl.instance.MusicOn(false);
        }
        else
        {
            musicButton.image.sprite = musicIcon[0];
            MusicControl.instance.MusicOn(true);
        }
    }

    public void Skor()
    {
        SceneManager.LoadScene("Score");
    }
}
