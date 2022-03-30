using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBackPanelController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject OptionPanel;
    public GameObject PauseCanvas;

    [SerializeField] MenuButtonController menuButtonController;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToPausePanel()
    {
        menuButtonController.index = 0;
        PauseCanvas.SetActive(true);
        OptionPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
