using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCounter : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Feet")
        {
            GetComponentInParent<Star>().StarOff();
            FindObjectOfType<Score>().CollectStar();
        }
    }

}
