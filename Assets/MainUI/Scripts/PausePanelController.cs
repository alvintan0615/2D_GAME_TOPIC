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
    public GameObject ComfirmToMainUICanvas;

    [SerializeField] MenuButtonController menuButtonController;

    public bool PausePanelisOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PausePanelisOpen == false )
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseCanvas.SetActive(true);
                PausePanel.SetActive(true);
                ToStopPanel();
            }
        }

    }

    //public void ClosePausePanel()
    //{
    //    menuButtonController.index = 0;
    //    ComfirmToMainUICanvas.gameObject.SetActive(false);
    //    PauseCanvas.gameObject.SetActive(false);
    //    QuitPanel.gameObject.SetActive(false);
    //    PausePanel.gameObject.SetActive(false);
    //}

    public void OpenConfirmToMainUI()
    {
        menuButtonController.index = 0;
        ComfirmToMainUICanvas.gameObject.SetActive(true);
        PauseCanvas.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
    }

    public void BackToGame()
    {
        menuButtonController.index = 0;
        PauseCanvas.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
    }

    public void ToStopPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(true);
        QuitPanel.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
    }

    public void PauseOpenQuitPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(true);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
    }

    public void PauseToMainUIPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        SceneManager.LoadScene("UITestScene");
    }

    
}
