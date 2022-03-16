using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject QuitPanel;
    public GameObject SettingsPanel;

    [SerializeField] MenuButtonController menuButtonController;

     public bool PausePanelisOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PausePanelisOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToStopPanel();
            }
        }

        if (PausePanelisOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuButtonController.index = 0;
                PausePanel.SetActive(true);
                SettingsPanel.SetActive(false);
                QuitPanel.SetActive(false);
            }
        }
    }



    public void ToStopPanel()
    {
        menuButtonController.index = 0;
        PausePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        QuitPanel.SetActive(false);
    }

    public void PauseOpenQuitPanel()
    {
        menuButtonController.index = 0;
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        QuitPanel.SetActive(true);
    }

    public void PauseOpenSettingsPanel()
    {
        menuButtonController.index = 0;
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
        QuitPanel.SetActive(false);
    }
}
