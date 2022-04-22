using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject QuitPanel;
    public GameObject PauseCanvas;
    public GameObject OpenOptionPanel;
    public GameObject ComfirmToMainUICanvas;

    [SerializeField] MenuButtonController menuButtonController;

    public bool PausePanelisOpen = false;
    public bool SettingPanelisOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        PausePanelisOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingPanelisOpen == true && PausePanelisOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("123");
            }
        }

        if (PausePanelisOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                PauseCanvas.SetActive(true);
                PausePanel.SetActive(false);
                BackToGame();
            }
        }

        if (PausePanelisOpen == false && SettingPanelisOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                PauseCanvas.SetActive(true);
                PausePanel.SetActive(true);
                ToStopPanel();
            }
        }



        //if (PausePanelisOpen == false && SettingPanelisOpen == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        Time.timeScale = 0;
        //        PauseCanvas.SetActive(true);
        //        PausePanel.SetActive(false);
        //        OpenOption();
        //    }
        //}

    }

    //public void ClosePausePanel()
    //{
    //    menuButtonController.index = 0;
    //    ComfirmToMainUICanvas.gameObject.SetActive(false);
    //    PauseCanvas.gameObject.SetActive(false);
    //    QuitPanel.gameObject.SetActive(false);
    //    PausePanel.gameObject.SetActive(false);
    //}

    public void OpenOption()
    {
        menuButtonController.index = 0;
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(true);
        SettingPanelisOpen = true;
        PausePanelisOpen = false;
        Debug.Log("Open");
    }

    public void OpenConfirmToMainUI()
    {
        menuButtonController.index = 0;
        ComfirmToMainUICanvas.gameObject.SetActive(true);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(false);
        SettingPanelisOpen = false;
        PausePanelisOpen = false;
    }

    public void BackToGame()
    {
        menuButtonController.index = 0;
        PauseCanvas.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        OpenOptionPanel.gameObject.SetActive(false);
        SettingPanelisOpen = false;
        PausePanelisOpen = false;
    }

    public void ToStopPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(true);
        QuitPanel.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(false);
        SettingPanelisOpen = false;
        PausePanelisOpen = true;
    }

    public void PauseOpenQuitPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(true);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(false);
        SettingPanelisOpen = false;
        PausePanelisOpen = false;
    }

    public void PauseToMainUIPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        OpenOptionPanel.gameObject.SetActive(false);
        SettingPanelisOpen = false;
        PausePanelisOpen = false;
        SceneManager.LoadScene("UITestScene");
    }

    
}
