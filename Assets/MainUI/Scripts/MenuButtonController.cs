using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public static MenuButtonController instance;
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource ClickSound;
    public AudioSource SelectSound;



    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index < maxIndex)
                {
                    index++;
                    SelectSound.Play();
                }
                else
                {
                    index = 0;
                    SelectSound.Play();
                }
            }

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (index > 0)
                {
                    index--;
                    SelectSound.Play();
                }
                else
                {
                    index = maxIndex;
                    SelectSound.Play();
                }
            }
        }
        MoveSelection();
    }

    public void MoveSelection()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++  ;
                        SelectSound.Play();
                    }
                    else
                    {
                        index = 0 ;
                        SelectSound.Play();
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                        SelectSound.Play();
                    }
                    else
                    {
                        index = maxIndex;
                        SelectSound.Play();
                    }
                }
                keyDown = true;
            }

        }
        else
        {
            keyDown = false;
        }
    }

}
