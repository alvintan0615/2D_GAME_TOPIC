using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenController : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] public int thisIndex;

    public Text YesText;
    public Text NoText;

    static public bool FullScreenOpen = true;
    static public bool OpenIsFullScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        FullScreenOpen = Screen.fullScreen;
        YesText.enabled = true;
        NoText.enabled = false;

        if(FullScreenOpen == true && NoText.enabled == true)
        {
            YesText.enabled = true;
            NoText.enabled = false;
            FullScreenOpen = true;
        }

        if (FullScreenOpen == false && YesText.enabled == true)
        {
            YesText.enabled = false;
            NoText.enabled = true;
            FullScreenOpen = false;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        Screen.fullScreen = FullScreenOpen;
        
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                YesText.enabled = true;
                NoText.enabled = false;
                FullScreenOpen = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                YesText.enabled = false;
                NoText.enabled = true;
                FullScreenOpen = false;
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
