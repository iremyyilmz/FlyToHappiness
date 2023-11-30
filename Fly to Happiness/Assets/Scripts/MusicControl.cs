using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl instance;
    AudioSource audioSource;

    void Awake()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }

    void Singleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void MusicOn(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
