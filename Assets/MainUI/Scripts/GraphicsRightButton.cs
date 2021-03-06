using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsRightButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                animator.SetBool("Pressed", true);
            }
            else if (animator.GetBool("Pressed"))
            {

                animator.SetBool("Pressed", false);
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
