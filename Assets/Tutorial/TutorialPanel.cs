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

            if (TutorialPanelOpen == true && JumpIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseJump();
            }

            if (TutorialPanelOpen == true && ClimbRopeIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseClimbRope();
            }

            if (TutorialPanelOpen == true && ClimbWallIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseClimbWall();
            }

            if (TutorialPanelOpen == true && JumpDashIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseJumpDash();
            }

            if (TutorialPanelOpen == true && MoveRockIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseMoveRock();
            }

            if (TutorialPanelOpen == true && JumpFireSkillIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                CloseJumpFireSkill();
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

        if (collision.tag == "Tutorial03")
        {
            OpenJump();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.tag == "Tutorial04")
        {
            OpenClimbRope();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.tag == "Tutorial05")
        {
            OpenClimbWall();
            Destroy(GameObject.FindWithTag("Tutorial05"));
            Time.timeScale = 0;
        }

        if (collision.tag == "Tutorial06")
        {
            OpenJumpDash();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.tag == "Tutorial07")
        {
            OpenMoveRock();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.tag == "Tutorial08")
        {
            OpenJumpFireSkill();
            Destroy(collision);
            Time.timeScale = 0;
        }
    }

    public void CloseJumpFireSkill()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        JumpFireSkill.SetActive(false);
        JumpFireSkillIsOpen = false;
    }

    public void OpenJumpFireSkill()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        JumpFireSkill.SetActive(true);
        JumpFireSkillIsOpen = true;
    }

    public void CloseMoveRock()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        MoveRock.SetActive(false);
        MoveRockIsOpen = false;
    }

    public void OpenMoveRock()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        MoveRock.SetActive(true);
        MoveRockIsOpen = true;
    }

    public void CloseJumpDash()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        JumpDash.SetActive(false);
        JumpDashIsOpen = false;
    }

    public void OpenJumpDash()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        JumpDash.SetActive(true);
        JumpDashIsOpen = true;
    }

    public void CloseClimbWall()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        ClimbWall.SetActive(false);
        ClimbWallIsOpen = false;
    }

    public void OpenClimbWall()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        ClimbWall.SetActive(true);
        ClimbWallIsOpen = true;
    }

    public void CloseClimbRope()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        ClimbRope.SetActive(false);
        ClimbRopeIsOpen = false;
    }

    public void OpenClimbRope()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        ClimbRope.SetActive(true);
        ClimbRopeIsOpen = true;
    }

    public void CloseJump()
    {
        tutorialPanel.SetActive(false);
        TutorialPanelOpen = false;
        Jump.SetActive(false);
        JumpIsOpen = false;
    }

    public void OpenJump()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        Jump.SetActive(true);
        JumpIsOpen = true;
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
