using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highestScore;

    int star;
    int highestStar;

    bool scorePoints = true;

    [SerializeField]
    Text scoreText = default;

    [SerializeField]
    Text starText = default;

    [SerializeField]
    Text GameOverScoreText = default;

    [SerializeField]
    Text GameOverStarText = default;


    void Start()
    {
        starText.text = " " + star;
    }

    void Update()
    {
        if(scorePoints)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Puan  " + score;
        }
        
    }

    public void CollectStar()
    {
        FindObjectOfType<SoundControl>().StarSound();
        star++;
        starText.text = " " + star;
    }

    public void GameOver()
    {
        if(Preferences.EasyValueRead() == 1)
        {
            highestStar = Preferences.EasyValueStarRead();

            if(star > highestStar)
            {
                Preferences.EasyValueStar(star);
            }
        }

        if (Preferences.MediumValueRead() == 1)
        {
            highestScore = Preferences.MediumValueScoreRead();
            highestStar = Preferences.MediumValueStarRead();

            if (score > highestScore)
            {
                Preferences.MediumValueScore(score);
            }

            if (star > highestStar)
            {
                Preferences.MediumValueStar(star);
            }
        }

        if (Preferences.HardValueRead() == 1)
        {
            highestScore = Preferences.HardValueScoreRead();
            highestStar = Preferences.HardValueStarRead();

            if (score > highestScore)
            {
                Preferences.HardValueScore(score);
            }

            if (star > highestStar)
            {
                Preferences.HardValueStar(star);
            }
        }

        scorePoints = false;
        GameOverScoreText.text = " " + score;
        GameOverStarText.text = " " + star;
    }
}
