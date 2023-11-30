using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }

    public void SliderDeger(int maksDeger, int gecerliDeger)
    {
        int sliderDeger = maksDeger - gecerliDeger;
        slider.maxValue = maksDeger;
        slider.value = sliderDeger;
    }
}
