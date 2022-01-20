using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControlButton : MonoBehaviour
{
    public GameObject ControlButtonPanel;
    public GameObject OptionPanel;

    public AudioSource Click;
    public Animator animator;

    [SerializeField] MenuButtonController menuButtonController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Submit") == 1 )
        {
            animator.SetBool("Pressed", true);
        }
        else if (animator.GetBool("Pressed"))
        {
            animator.SetBool("Pressed", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Click.Play();
            menuButtonController.index = 0;
            ToOptionPanel();
        }
    }

    public void PlayClickSound()
    {
        Click.Play();
    }

    public void ToOptionPanel()
    {
        menuButtonController.index = 0;
        ControlButtonPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void ToControlButtonPanel()
    {
        ControlButtonPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }
}
