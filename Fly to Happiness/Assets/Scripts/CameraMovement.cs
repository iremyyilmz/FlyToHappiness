using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float speed;
    float speedUp;
    float maxSpeed;

    bool movement;

    void Start()
    {
        movement = true;

        if(Preferences.EasyValueRead() == 1)
        {
            speed = 0.3f;
            speedUp = 0.03f;
            maxSpeed = 1.5f;
        }

        if(Preferences.MediumValueRead() == 1)
        {
            speed = 0.5f;
            speedUp = 0.05f;
            maxSpeed = 2.0f;
        }

        if(Preferences.HardValueRead() == 1)
        {
            speed = 0.7f;
            speedUp = 0.07f;
            maxSpeed = 2.5f;
        }

    }

    void Update()
    {
        if (movement)
        {
         MoveTheCamera();
        }
        
    }

    void MoveTheCamera()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += speedUp * Time.deltaTime;
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void GameOver()
    {
        movement = false;
    }
}
