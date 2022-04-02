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
               // Time.timeScale = 0;
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

    public void OpenOption()
    {
        menuButtonController.index = 0;
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(true);
    }

    public void OpenConfirmToMainUI()
    {
        menuButtonController.index = 0;
        ComfirmToMainUICanvas.gameObject.SetActive(true);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(false);
    }

    public void BackToGame()
    {
        //Time.timeScale = 1;
        menuButtonController.index = 0;
        PauseCanvas.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        OpenOptionPanel.gameObject.SetActive(false);
    }

    public void ToStopPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(true);
        QuitPanel.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(false);
        
    }

    public void PauseOpenQuitPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(true);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
        OpenOptionPanel.gameObject.SetActive(false);
    }

    public void PauseToMainUIPanel()
    {
        menuButtonController.index = 0;
        PausePanel.gameObject.SetActive(false);
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(false);
        ComfirmToMainUICanvas.gameObject.SetActive(false);
        OpenOptionPanel.gameObject.SetActive(false);
        SceneManager.LoadScene("UITestScene");
    }

    
}
