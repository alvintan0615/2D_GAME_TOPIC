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
    public GameObject DemonDescription;
    public GameObject ChangeMode;
    public GameObject DemonNormalAtk;
    public GameObject DemonBeamSkill;
    public GameObject DemonDoubleJump;
    public GameObject DemonDash;

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

    public bool CanOpenDemonPanel = false;

    public bool DemonDescriptionIsOpen = false;
    public bool ChangeModeIsOpen = false;
    public bool DemonNormalAtkIsOpen = false;
    public bool DemonBeamSkillIsOpen = false;
    public bool DemonDoubleJumpIsOpen = false;
    public bool DemonDashIsOpen = false;
    
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

        DemonDescription = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(11).gameObject;
        ChangeMode = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(12).gameObject;
        DemonNormalAtk = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(13).gameObject;
        DemonBeamSkill = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(14).gameObject;
        DemonDoubleJump = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(15).gameObject;
        DemonDash = GameObject.Find("TutorialCanvas").gameObject.transform.GetChild(0).GetChild(16).gameObject;

        TutorialPanelOpen = false;
        tutorialPanel.SetActive(false);

        CanOpenDemonPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanOpenDemonPanel == true)
        {
            OpenDemonDescription();
            Time.timeScale = 0;
        }

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

            if (TutorialPanelOpen == true && DemonDescriptionIsOpen == true && Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 0;
                CloseDemonDescription();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "WalkCollider")
        {
            OpenWalk();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.name == "NormalAtkCollider")
        {
            OpenNormalAtk();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.name == "JumpCollider")
        {
            OpenJump();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.name == "ClimbRopeCollider")
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

        if (collision.name == "JumpDashCollider")
        {
            OpenJumpDash();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.name == "MoveRockCollider")
        {
            OpenMoveRock();
            Destroy(collision);
            Time.timeScale = 0;
        }

        if (collision.name == "JumpFireSkillCollider")
        {
            OpenJumpFireSkill();
            Destroy(collision);
            Time.timeScale = 0;
        }
    }

    public void OpenChangeMode()
    {

    }

    public void CloseDemonDescription()
    {
        TutorialPanelOpen = true;

        DemonDescription.SetActive(false);
        DemonDescriptionIsOpen = false;
    }

    public void OpenDemonDescription()
    {
        tutorialPanel.SetActive(true);
        TutorialPanelOpen = true;
        DemonDescription.SetActive(true);
        DemonDescriptionIsOpen = true;
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
        yield return new WaitForSecondsRealtime(1); 
        FireSkillIsOpen = true;
    }

    IEnumerator DelayGroundSkillOpenKey()
    {
        yield return new WaitForSecondsRealtime(1); 
        GroundSkillIsOpen = true;
    }

    IEnumerator DelayDashOpenKey()
    {
        yield return new WaitForSecondsRealtime(1);
        DashIsOpen = true;
    }
}
