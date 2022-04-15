using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_SecondPart : MonoBehaviour
{
    public GameObject electricBall;
    private GameObject electricBallPos;
    public GameObject knockBackLight;
    private GameObject knockBackLightPos;
    private GameObject player;
    private void OnEnable()
    {
        electricBallPos = transform.GetChild(2).gameObject;
        knockBackLightPos = transform.GetChild(3).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CreateElectricBall()
    {
        Instantiate(electricBall, electricBallPos.transform.position, Quaternion.identity);
    }

    public void CreateknockBackLight()
    {
        Instantiate(knockBackLight, knockBackLightPos.transform.position, Quaternion.identity);
    }
}
