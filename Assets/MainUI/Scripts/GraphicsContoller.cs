using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsContoller : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] public int thisIndex;

    public int qualityLevel = 3;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;

    // Start is called before the first frame update
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

            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                qualityLevel = qualityLevel - 1;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                qualityLevel = qualityLevel + 1;
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }

        if (qualityLevel <= 0)
        {
            qualityLevel = 0;
        }

        if (qualityLevel >= 5)
        {
            qualityLevel = 5;
        }

        if(qualityLevel == 0)
        {
            text1.enabled = true;
            text2.enabled = false;
            text3.enabled = false;
            text4.enabled = false;
            text5.enabled = false;
            text6.enabled = false;
        }

        if (qualityLevel == 1)
        {
            text1.enabled = false;
            text2.enabled = true;
            text3.enabled = false;
            text4.enabled = false;
            text5.enabled = false;
            text6.enabled = false;
        }

        if (qualityLevel == 2)
        {
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = true;
            text4.enabled = false;
            text5.enabled = false;
            text6.enabled = false;
        }

        if (qualityLevel == 3)
        {
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = false;
            text4.enabled = true;
            text5.enabled = false;
            text6.enabled = false;
        }

        if (qualityLevel == 4)
        {
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = false;
            text4.enabled = false;
            text5.enabled = true;
            text6.enabled = false;
        }

        if (qualityLevel == 5)
        {
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = false;
            text4.enabled = false;
            text5.enabled = false;
            text6.enabled = true;
        }

    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }
}
