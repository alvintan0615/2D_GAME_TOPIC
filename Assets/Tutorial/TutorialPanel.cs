using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject walk;
    public GameObject NormalAtk;
    public GameObject FireSkill;
    public GameObject GroundSkill;
    public GameObject Dash;
    public GameObject Jump;
    public GameObject ClimbRope;
    public GameObject ClimbWall;
    public GameObject JumpDash;
    public GameObject MoveRock;
    public GameObject JumpFireSkill;


    public bool TutorialPanelOpen = false;

    public bool walkIsOpen = false;
    public bool NormalAtkIsOpen = false;
    public bool FireSkillIsOpen = false;
    public bool GroundSkillIsOpen = false;
    public bool DashIsOpen = false;
    public bool JumpIsOpen = false;
    public bool ClimbRopeIsOpen = false;
    public bool ClimbWallIsOpen = false;
    public bool JumpDashIsOpen = false;
    public bool MoveRockIsOpen = false;
    public bool JumpFireSkillIsOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        tutorialPanel = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).gameObject;
        walk = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(0).gameObject;
        NormalAtk = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(1).gameObject;
        FireSkill = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(2).gameObject;
        GroundSkill = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(3).gameObject;
        Dash = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(4).gameObject;
        Jump = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(5).gameObject;
        ClimbRope = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(6).gameObject;
        ClimbWall = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(7).gameObject;
        JumpDash = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(8).gameObject;
        MoveRock = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(9).gameObject;
        JumpFireSkill = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(10).gameObject;

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

            if (TutorialPanelOpen == true && NormalAtkIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 0;
                CloseNormalAtk();
                OpenFireSkill();
            }

            if (TutorialPanelOpen == true && FireSkillIsOpen == true  && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 0;
                CloseFireSkill();
                OpenGroundSkill();
            }

            if (TutorialPanelOpen == true && GroundSkillIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 0;
                CloseGroundSkill();
                OpenDash();
            }

            if (TutorialPanelOpen == true && DashIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseDash();
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

        if (collision.tag == "Tutorial02")
        {
            OpenNormalAtk();
            Destroy(collision);
            Time.timeScale = 0;
        }
    }

    public void CloseDash()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        Dash.SetActive(false);
        DashIsOpen = false;
    }

    public void OpenDash()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        Dash.SetActive(true);
        StartCoroutine(DelayDashOpenKey());
    }

    public void CloseGroundSkill()
    {
        TutorialPanelOpen = true;

        GroundSkill.SetActive(false);
        GroundSkillIsOpen = false;
    }

    public void OpenGroundSkill()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        GroundSkill.SetActive(true);
        StartCoroutine(DelayGroundSkillOpenKey());
    }

    public void CloseFireSkill()
    {
        TutorialPanelOpen = true;

        FireSkill.SetActive(false);
        FireSkillIsOpen = false;
    }

    public void OpenFireSkill()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        FireSkill.SetActive(true);
        StartCoroutine(DelayFireSkillOpenKey());
    }

    public void CloseNormalAtk()
    {
        TutorialPanelOpen = true;

        NormalAtk.SetActive(false);
        NormalAtkIsOpen = false;
    }

    public void OpenNormalAtk()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        NormalAtk.SetActive(true);
        NormalAtkIsOpen = true;
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

    IEnumerator DelayFireSkillOpenKey()
    {
        yield return new WaitForSecondsRealtime(1); ;
        FireSkillIsOpen = true;
    }

    IEnumerator DelayGroundSkillOpenKey()
    {
        yield return new WaitForSecondsRealtime(1); ;
        GroundSkillIsOpen = true;
    }

    IEnumerator DelayDashOpenKey()
    {
        yield return new WaitForSecondsRealtime(1); ;
        DashIsOpen = true;
    }
}
