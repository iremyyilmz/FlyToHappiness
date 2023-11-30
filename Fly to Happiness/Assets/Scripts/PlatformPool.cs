using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    List<GameObject> platformPrefab = new List<GameObject>();

    Vector2 platformPosition;

    [SerializeField]
    GameObject playerPrefab = default;

    [SerializeField]
    List<GameObject> deadlyPlatformPrefab = new List<GameObject>();

    Vector2 playerPosition;

    [SerializeField]
    float platformArasiMesafe = default;

    List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        PlatformUret();
    }

    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            PlatformYerlestir();
        }
    }

    void PlatformUret()
    {
        platformPosition = new Vector2(0, -1.0f);
        playerPosition = new Vector2(1.0f, -3.4f);

        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab[Random.Range(0, 3)], platformPosition, Quaternion.identity);
        platforms.Add(firstPlatform);
        firstPlatform.GetComponent<Platform>().Move = false;
        YeniPlatformPozisyon();
        

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab[Random.Range(0, 3)], platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Move = true;
            if(i % 2 == 0)
            {
                platform.GetComponent<Star>().StarOn();
            }
            YeniPlatformPozisyon();

        }

        GameObject deadlyPlatform = Instantiate(deadlyPlatformPrefab[Random.Range(0, 2)], platformPosition, Quaternion.identity);
        platforms.Add(deadlyPlatform);
        deadlyPlatform.GetComponent<DeadlyPlatform>().Move = true;
        YeniPlatformPozisyon();

    }

    void PlatformYerlestir()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;
            if(platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Star>().StarOff();
                float randomStar = Random.Range(0.0f, 1.0f);
                if(randomStar > 0.6)
                {
                    platforms[i + 5].GetComponent<Star>().StarOn();
                }
            }
            YeniPlatformPozisyon();
        }
    }

    void YeniPlatformPozisyon()
    {
        platformPosition.y += platformArasiMesafe;
        SiraliPozisyon();
    }

    void KarisikPozisyon()
    {
        float random = Random.Range(0.0f, 1.0f);

        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;
        }
    }

    bool yon = true;

    void SiraliPozisyon()
    {
        if (yon)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
            yon = false;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;
            yon = true;
        }
    }
}
