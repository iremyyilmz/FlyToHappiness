using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject ziplamaButonu;
    public GameObject tabela;
    public GameObject menuButonu;
    public GameObject slider;

    public void Start()
    {
        gameOverPanel.SetActive(false);
        UIOpen();
    }

    public void GameOver()
    {
        FindObjectOfType<SoundControl>().GameOverSound();
        gameOverPanel.SetActive(true);
        FindObjectOfType<Score>().GameOver();
        FindObjectOfType<PlayerControl>().Gameover();
        FindObjectOfType<CameraMovement>().GameOver();
        UIClose();
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void UIOpen()
    {
        joystick.SetActive(true);
        ziplamaButonu.SetActive(true);
        tabela.SetActive(true);
        menuButonu.SetActive(true);
        slider.SetActive(true);
    }

    void UIClose()
    {
        joystick.SetActive(false);
        ziplamaButonu.SetActive(false);
        tabela.SetActive(false);
        menuButonu.SetActive(false);
        slider.SetActive(false);
    }
}
