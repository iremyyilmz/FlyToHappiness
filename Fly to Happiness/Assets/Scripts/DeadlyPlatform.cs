using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    bool move;
    float randomSpeed;

    float min, max;

    public bool Move
    {
        get
        {
            return move;
        }

        set
        {
            move = value;
        }
    }


    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);

        float objectWidth = boxCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    
    void Update()
    {
        float pingpongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
        Vector2 pingpong = new Vector2(pingpongX, transform.position.y);
        transform.position = pingpong;
    }


}
