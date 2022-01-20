using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSelection : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] public int thisIndex;
    public Dropdown dropdown;

    bool dropdownIsSelected = false;
    bool dropdownIsControl = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetQuality();

        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if(Input.GetKeyDown(KeyCode.Return))
            {
                dropdownIsSelected = true;
                menuButtonController.enabled = false;
            }
            if(dropdownIsControl == true && Input.GetKeyDown(KeyCode.Return))
            {
                dropdownIsSelected = false;
                dropdownIsControl = false;
                menuButtonController.enabled = true;
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }

        if(dropdownIsSelected == true)
        {
            dropdownIsControl = true;
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                dropdown.value = dropdown.value + 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                dropdown.value = dropdown.value - 1;
            }

        }
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
    }

}
