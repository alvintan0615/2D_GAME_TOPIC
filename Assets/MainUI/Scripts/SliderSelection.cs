using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSelection : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] public int thisIndex;
    public Slider slider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < 0)
        {
            slider.value = 0;
        }

        if (slider.value > 1)
        {
            slider.value = 1;
        }

        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                slider.value = slider.value - 0.1f;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                slider.value = slider.value + 0.1f;
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
