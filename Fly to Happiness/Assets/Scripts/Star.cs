using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    GameObject star = default;
   
    public void StarOn()
    {
        star.SetActive(true);
    }

    public void StarOff()
    {
        star.SetActive(false);
    }
}
