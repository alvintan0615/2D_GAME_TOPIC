using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D newAttackTrigger;
    [SerializeField] private ContactFilter2D woodFilter;
    [SerializeField] private int woodCount;
    [SerializeField] private Collider2D[] woodColList;

    [SerializeField] private ContactFilter2D HPFlowerFilter;
    [SerializeField] private int FlowerCount;
    [SerializeField] private Collider2D[] FlowerColList;
    void Start()
    {
        newAttackTrigger = transform.GetChild(0).GetComponent<BoxCollider2D>();
        woodFilter.SetLayerMask(LayerMask.GetMask("DestoryWood"));
        HPFlowerFilter.SetLayerMask(LayerMask.GetMask("HPFlower"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        woodColList = new Collider2D[2];
        woodCount = newAttackTrigger.OverlapCollider(woodFilter, woodColList);

        if (woodCount > 0)
        {
            for (int i = 0; i < woodCount; i++)
            {
                var enemyAnim = woodColList[i].GetComponent<Animator>();
                enemyAnim.SetBool("isTrigger", true);

            }
        }
    }

    public void FlowerHeal()
    {
        FlowerColList = new Collider2D[5];
        FlowerCount = newAttackTrigger.OverlapCollider(HPFlowerFilter, FlowerColList);

        if (FlowerCount > 0)
        {
            for (int i = 0; i < FlowerCount; i++)
            {
                //Destroy(FlowerColList[i].gameObject);
                GameManager.Instance.playerStats.characterData.currentHealth += Random.Range(5, 10);
                var flowerDestory = FlowerColList[i].GetComponent<HPFlower>();
                flowerDestory.isSlowDestory = true;
            }
        }
    }
}
