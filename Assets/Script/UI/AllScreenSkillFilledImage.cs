using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScreenSkillFilledImage : MonoBehaviour
{
    [SerializeField] private GameObject[] iCon;
    void Start()
    {
        iCon[0] = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.Instance.canUseAllSceenSkill == true)
            iCon[0].SetActive(false);
        else if (EventManager.Instance.canUseAllSceenSkill == false)
            iCon[0].SetActive(true);
    }
}
