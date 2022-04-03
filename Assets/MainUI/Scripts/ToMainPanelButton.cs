using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainPanelButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;

    [SerializeField] PausePanelController pausePanelController;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            if (menuButtonController.index == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    click.Play();
                    pausePanelController.ToStopPanel();
                }
            }

            if (menuButtonController.index == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    click.Play();
                    pausePanelController.PauseToMainUIPanel();
                    Time.timeScale = 1;
                }
            }
        }
    }
}
