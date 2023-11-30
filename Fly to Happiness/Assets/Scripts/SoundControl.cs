using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioClip star;
    public AudioClip jump;
    public AudioClip gameOver;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StarSound()
    {
        audioSource.clip = star;
        audioSource.Play();
    }

    public void JumpSound()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
