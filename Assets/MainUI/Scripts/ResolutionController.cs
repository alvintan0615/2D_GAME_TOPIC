using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    //private static readonly string ResolutionPref = "ResolutionStringPref";
    //private static readonly string HorizontalPref = "HorizontalPref";
    //private static readonly string VerticalPref = "VorizontalPref";

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] public int thisIndex;

    public List<ResItem> resolutions = new List<ResItem>();
    public int selectResolution;

    public Text resolutionText;
    

    void Start()
    {
        //getResolutionPref();
        //setResolutionPref();

        UpdateResText();

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectResolution = i;

                UpdateResText();
            }
        }

        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectResolution = resolutions.Count - 1;

            UpdateResText();
        }
    }
    void Update()
    {
         //getResolutionPref();
        //setResolutionPref();
        

        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ResLeft();
                ApplyResolution();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ResRight();
                ApplyResolution();
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }

    //public void getResolutionPref()
    //{
    //    resolutionText.text = PlayerPrefs.GetString("ResolutionStringPref");
    //    PlayerPrefs.GetInt("HorizontalPref");
    //    PlayerPrefs.GetInt("VorizontalPref");
    //}

    //public void setResolutionPref()
    //{
    //    PlayerPrefs.SetString("ResolutionStringPref", resolutionText.text);
    //    PlayerPrefs.SetInt("HorizontalPref", resolutions[selectResolution].horizontal);
    //    PlayerPrefs.SetInt("VorizontalPref", resolutions[selectResolution].vertical);
    //}

    public void ResLeft()
    {
        selectResolution--;
        if(selectResolution < 0)
        {
            selectResolution = 0;
        }

        UpdateResText();
    }

    public void ResRight()
    {
        selectResolution++;
        if (selectResolution > resolutions.Count -1)
        {
            selectResolution = resolutions.Count - 1;
        }

        UpdateResText();
    }

    public void ApplyResolution()
    {
        //Screen.SetResolution(resolutions[selectResolution].horizontal, resolutions[selectResolution].vertical, Screen.fullScreen) ;
        Screen.SetResolution(resolutions[selectResolution].horizontal, resolutions[selectResolution].vertical, Screen.fullScreen);
    }

    public void UpdateResText()
    {
        resolutionText.text = resolutions[selectResolution].horizontal.ToString() + "X" + resolutions[selectResolution].vertical.ToString();
    }

    [System.Serializable]
    public class ResItem
    {
       public int horizontal, vertical;
    }
}
