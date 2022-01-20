using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] public int thisIndex;

    public List<ResItem> resolutions = new List<ResItem>();
    public int selectResolution;

    public Text resolutionText;

    void Start()
    {
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
