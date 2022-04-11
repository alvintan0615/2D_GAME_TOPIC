using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject walk;

    

    public bool TutorialPanelOpen = false;

    public bool walkIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
        tutorialPanel = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).gameObject;
        walk = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(0).gameObject;
        TutorialPanelOpen = false;
        tutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            if (TutorialPanelOpen == true && walkIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseWalk();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tutorial01")
        {
            OpenWalk();
            Destroy(collision);
            Time.timeScale = 0;
        }
    }

    public void CloseWalk()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        walk.SetActive(false);
        walkIsOpen = false;
    }

    public void OpenWalk()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        walk.SetActive(true);
        walkIsOpen = true;
    }
}
