using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject Button;
    public Canvas SecondCanvas;
    public Animator animator;

    public AudioSource Click;

    public bool BurnIsFin = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) && BurnIsFin == true)
            {
                Click.Play();
                SwicthToSecondCanvas();
            }
    }

    public void SwicthToSecondCanvas()
    {
        Button.gameObject.SetActive(false);
        SecondCanvas.gameObject.SetActive(true);
    }
}
