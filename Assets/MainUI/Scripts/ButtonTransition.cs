using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonTransition : MonoBehaviour
{
    //public GameObject Background;
    public GameObject UIMain;
    public GameObject ContinueOption;
    public GameObject Option;
    public GameObject QuitPanel;
    public GameObject Logo;
    public GameObject PauseCanvas;
    
   

    static public bool OptionIsOpen = false;
    static public bool ContinueIsOpen = false;
    static public bool OnMainUI = true;

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] MenuButtonController QuitPanelMenuButtonController;
    [SerializeField] MenuButton NewGameMenuButton;
    [SerializeField] MenuButton ContimueMenuButton;
    [SerializeField] MenuButton OptionMenuButton;
    [SerializeField] MenuButton QuitMenuButton;

    [SerializeField] AudioManager audioManager;

    public AudioSource ClickSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OptionMenuButton.enabled == true || ContimueMenuButton.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToUIMain();
                ClickSound.Play();
                audioManager.SaveSoundSesttings();
            }
        }
    }

    public void ToNewGame()
    {
        OnMainUI = false;
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("sceneName");
        PlayerPrefs.DeleteKey("playerStats");
        EventManager.Instance.AllEventToFalse();
        SceneController.Instance.TransitionToFirstLevel();
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void CloseQuitPanel()
    {
        QuitPanel.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(false);
        menuButtonController.enabled = true;
        menuButtonController.index = 0;
        QuitPanelMenuButtonController.index = 0;
        menuButtonController.enabled = true;
        NewGameMenuButton.enabled = true;
        ContimueMenuButton.enabled = true;
        OptionMenuButton.enabled = true;
        QuitMenuButton.enabled = true;
        
    }
    public void OpenQuitPanel()
    {
        QuitPanel.gameObject.SetActive(true);
        menuButtonController.index = 0;
        menuButtonController.enabled = false;
        NewGameMenuButton.enabled = false;
        ContimueMenuButton.enabled = false;
        OptionMenuButton.enabled = false;
        QuitMenuButton.enabled = false;
    }

    public void ToOption()
    {
        OptionIsOpen = true;
        UIMain.gameObject.SetActive(false);
        ContinueOption.gameObject.SetActive(false);
        Option.gameObject.SetActive(true);
        menuButtonController.index = 0;
        Debug.Log("toOption");
        Logo.gameObject.SetActive(false);
        //MenuButtonController.instance.index = 0;
    }

    public void ToContinueOption()
    {
        UIMain.gameObject.SetActive(false);
        Option.gameObject.SetActive(false);
        ContinueOption.gameObject.SetActive(true);
        ContinueIsOpen = true;
        menuButtonController.index = 0;
        Debug.Log("ToContinueOption");
        Logo.gameObject.SetActive(false);
        //MenuButtonController.instance.index = 0;
    }

    public void ToUIMain()
    {
        ContinueOption.gameObject.SetActive(false);
        Option.gameObject.SetActive(false);
        UIMain.gameObject.SetActive(true);
        menuButtonController.index = 0;
        audioManager.SaveSoundSesttings();
        Logo.gameObject.SetActive(true);
        Debug.Log("ToUIMain");
        //MenuButtonController.instance.index = 0;
    }
}
