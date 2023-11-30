using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
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

        if (Preferences.EasyValueRead() == 1)
        {
            randomSpeed = Random.Range(0.4f, 1.0f);
        }

        if (Preferences.MediumValueRead() == 1)
        {
            randomSpeed = Random.Range(0.7f, 1.5f);
        }

        if (Preferences.HardValueRead() == 1)
        {
            randomSpeed = Random.Range(0.9f, 2.0f);
        }

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Feet")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerControl>().ResetJumping();
        }
    }
}
