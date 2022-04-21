using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventManager : Singleton<EventManager>
{
    public bool canChange = false;
    public bool canUsePotion = false;
    public bool canUseAllSceenSkill = false;
    public bool PassTutorial = false;
    public bool takeFood = false;
    public bool fireAlarm = false;
    public bool fireVillege_Timeline = false;
    public bool fireVillege_Dialog = false;
    public bool fireVillege_Dad = false;
    public bool fireVillege_BossStoryLine = false;
    public bool fireVillege_TimelineBeforeToriBoss = false;
    public bool fireVillege_DialogBeforeToriBoss = false;
    public bool fireVillege_TimelineChangeDemon = false;
    public bool fireVillege_TimelineFinish = false;
    public bool Dungeon_Opening = false;
    public bool Sewer_TimeLineBossTori = false;
    public bool timeLineBossStop = false;
    public bool isFirstTimeToPass = false;
    public bool electricDoor = false;
    public bool isTori_SewerDead = false;
    public bool isGetFinalBossdoorKey = false;
    public bool isFinalBossDoorOpen = false;
    public bool finalBossOpen = false;
    public bool finalbossExcuseVideo = false;
    public bool finalBossStart = false;
    public bool isFirstPartBossDead = false;
    public bool isFinalBossLetPlayerDead = false;
    public bool finalBossMiddle = false;

    public bool HasFirstTalk = false;
    public bool firstNormalAtk = false;
    public bool SecondNormalAtk = false;
    public bool FireSkill = false;
    public bool GroundSkill = false;
    public bool Jump = false;
    public bool Dash = false;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        /*eventFlowchart = transform.GetChild(0).GetComponent<Flowchart>();
        dialogFlowchart = transform.GetChild(1).GetComponent<Flowchart>();
        KeyInputFlowChart = transform.GetChild(2).GetComponent<Flowchart>();*/
    }
    void Update()
    {
            /*takeFood = true;
            fireAlarm = true;*/
    }

    public void AllEventToFalse()
    {
    canChange = false;
    canUseAllSceenSkill = false;
    takeFood = false;
    fireAlarm = false;
    fireVillege_Timeline = false;
    fireVillege_Dialog = false;
    fireVillege_Dad = false;
    fireVillege_BossStoryLine = false;
    fireVillege_TimelineBeforeToriBoss = false;
    fireVillege_DialogBeforeToriBoss = false;
    fireVillege_TimelineChangeDemon = false;
    fireVillege_TimelineFinish = false;
    timeLineBossStop = false;
}

}
