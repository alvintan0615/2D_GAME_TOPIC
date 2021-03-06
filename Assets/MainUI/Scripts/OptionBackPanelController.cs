using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBackPanelController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject OptionPanel;
    public GameObject PauseCanvas;

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] int thisIndex;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            if (menuButtonController.index == thisIndex)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    click.Play();
                    menuButtonController.index = 0;
                    PauseCanvas.SetActive(true);
                    OptionPanel.SetActive(false);
                    PausePanel.SetActive(true);
                }
            }
        }
    }

    public void BackToPausePanel()
    {
        menuButtonController.index = 0;
        PauseCanvas.SetActive(true);
        OptionPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
