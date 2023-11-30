using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.x < -ScreenCalculator.instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = -ScreenCalculator.instance.Width;
            transform.position = temp;
        }

        if (transform.position.x > ScreenCalculator.instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = ScreenCalculator.instance.Width;
            transform.position = temp;
        }
    }
}
