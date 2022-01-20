using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningBurnCanvas : MonoBehaviour
{
    [SerializeField] SwitchCanvas switchCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cantSpaceBar()
    {
        switchCanvas.BurnIsFin = false;
    }

    public void canSpaceBar()
    {
        switchCanvas.BurnIsFin = true;
    }
}
