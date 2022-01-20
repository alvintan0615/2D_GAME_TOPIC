using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHead : MonoBehaviour
{
    [SerializeField]private GameObject[] head;

    private void Start()
    {
        head[0] = transform.GetChild(0).gameObject;
        head[1] = transform.GetChild(1).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Ken_Human == true)
        {
            head[0].SetActive(true);
            head[1].SetActive(false);
        }
        else
        {
            head[0].SetActive(false);
            head[1].SetActive(true);
        }
    }
}
