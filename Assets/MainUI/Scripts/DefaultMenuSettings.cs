using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMenuSettings : MonoBehaviour
{
    //public GameObject Background;
    public GameObject UIMain;
    public GameObject ContinueOption;
    public GameObject Option;
    public GameObject QuitPanel;

    public AudioSource ClickSound;
    [SerializeField] AudioManager audioManager;
    void Start()
    {
       // ToDefaultMainUI();
    }

    // Update is called once per frame
    void Update()
    {
        //if(ButtonTransition.OptionIsOpen == true || ButtonTransition.ContinueIsOpen == true)
        //{
        //    if(Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        ToDefaultMainUI();
        //        ClickSound.Play();
        //        audioManager.SaveSoundSesttings();
        //    }
        //}
    }

    public void ToDefaultMainUI()
    {
        ContinueOption.gameObject.SetActive(false);
        Option.gameObject.SetActive(false);
        UIMain.gameObject.SetActive(true);
        QuitPanel.gameObject.SetActive(false);
    }
}
