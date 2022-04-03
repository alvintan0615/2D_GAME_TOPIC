using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;

    [SerializeField] PausePanelController pausePanelController;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            if (menuButtonController.index == thisIndex)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("resume");
                    click.Play();
                    StartCoroutine(cantJump());
                    Time.timeScale = 1;
                    pausePanelController.BackToGame();
                }
            }
        }


    }

    IEnumerator cantJump()
    {
        PlayerStatus.canJump = false;
        yield return new WaitForSeconds(0.3f);
        PlayerStatus.canJump = true;
    }
}
