using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [Header("變身相關")]
    public GameObject[] player_Form = { null, null };

    private void Awake()
    {
        player_Form[0] = this.transform.GetChild(0).gameObject;
        player_Form[1] = this.transform.GetChild(1).gameObject;
    }
    void Start()
    {
        
    }

    void Update()
    {
        /*if (player_Form[0].activeSelf)
        {
            GameManager.Instance.Ken_Human = true;
        }
        else if (player_Form[1].activeSelf)
        {
            GameManager.Instance.Ken_Human = false;
        }*/

        if ((Input.GetKeyDown(KeyCode.V)) && EventManager.Instance.canChange == true && PlayerStatus.canChange == true)
        {
            if (player_Form[0].activeSelf)
            {
                GameManager.Instance.Ken_Human = false;
                StartCoroutine(isChange());
                //ChangeForm();
            }
            else
            {
                GameManager.Instance.Ken_Human = true;
                StartCoroutine(isChange());
                //ChangeForm();
            }
        }

    }

    public void ChangeForm()
    {
        if (GameManager.Instance.Ken_Human == true)
        {
            player_Form[0].SetActive(true);
            player_Form[1].SetActive(false);
            //TODO 變身特效 用IEnumerator跟PlayerStatus限制

        }
        else
        {
            player_Form[0].SetActive(false);
            player_Form[1].SetActive(true);
            //TODO 變身特效 用IEnumerator跟PlayerStatus限制
            
        }
    }

    IEnumerator isChange()
    {
        PlayerStatus.isChanging = true;
        yield return new WaitForSeconds(1.15f);
        PlayerStatus.isChanging = false;
    }


}
