using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderContoller : MonoBehaviour
{
    public Slider slider;
    void Start()
    {

    }

     void Update()
    {
        ControlSliderValue();
    }

    public void ControlSliderValue()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            slider.value = slider.value - 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            slider.value = slider.value + 0.1f;
        }

        if (slider.value < 0)
        {
            slider.value = 0;
        }

        if (slider.value > 1)
        {
            slider.value = 1;
        }
    }
}
