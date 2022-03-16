using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBackPanelController : MonoBehaviour
{
    public GameObject BackButton;
    public GameObject StopBackButton;

    // Start is called before the first frame update
    void Start()
    {
        StopBackButton.SetActive(true);
        BackButton.SetActive(false);
        ButtonTransition.OnMainUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonTransition.OnMainUI == true)
        {
            BackButton.SetActive(true);
            StopBackButton.SetActive(false);
        }

        if(ButtonTransition.OnMainUI == false )
        {
            BackButton.SetActive(false);
            StopBackButton.SetActive(true);
        }
    }
}
