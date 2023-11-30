using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    float bgTransform;
    float distance = 10.26f;

    void Start()
    {
        bgTransform = transform.position.y;
        FindObjectOfType<Monster>().MonsterTransform(bgTransform);
    }

    void Update()
    {
        if(bgTransform + distance < Camera.main.transform.position.y)
        {
            BgLocation();
        }
    }

    void BgLocation()
    {
        bgTransform += (distance * 2);
        FindObjectOfType<Monster>().MonsterTransform(bgTransform);
        Vector2 newPosition = new Vector2(0, bgTransform);
        transform.position = newPosition;
    }
}
