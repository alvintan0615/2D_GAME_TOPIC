using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogSystem : MonoBehaviour
{
    [Header("UI配件")]
    public Text textLabel;
    public Image faceImage;

    [Header("腳本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("角色圖片")]
    public Sprite Ken, Father;

    bool textFinished;
    bool cancelTyping;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        textFinished = true;
        index = 0;
        StartCoroutine(SetTextUI());
    }

    private void OnDisable()
    {
        PlayerStatus.isDialouging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index])
        {
            case "MainCharacter":
                faceImage.sprite = Ken;
                PlayerStatus.isDialouging = true;
                index++;
                break;
            case "FATHER":
                faceImage.sprite = Father;
                PlayerStatus.isDialouging = true;
                index++;
                break;
            case "FOOD":
                EventManager.Instance.takeFood = true;
                EventManager.Instance.fireAlarm = true;
                PlayerStatus.isDialouging = false;
                gameObject.SetActive(false);
                break;
            case "CANMOVE":
                PlayerStatus.isDialouging = false;
                gameObject.SetActive(false);
                break;
            case "fireVillege_Dialog":
                EventManager.Instance.fireVillege_Dialog = false;
                PlayerStatus.isDialouging = true;
                faceImage.sprite = Ken;
                index ++;
                break;
            case "fireVillege_Dad":
                PlayerStatus.isDialouging = true;
                faceImage.sprite = Ken;
                index++;
                break;
            case "fireVillege_DadCanMove":
                EventManager.Instance.fireVillege_Dad = true;
                PlayerStatus.isDialouging = false;
                gameObject.SetActive(false);
                break;
            case "fireVillege_DialogBeforeToriBoss":
                EventManager.Instance.fireVillege_DialogBeforeToriBoss = true;
                PlayerStatus.isDialouging = false;
                gameObject.SetActive(false);
                break;
        }
        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
