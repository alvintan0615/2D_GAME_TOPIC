using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) //Fastest Quality
        {
            QualitySettings.SetQualityLevel(0, true);
        }

        if (Input.GetKeyDown("2")) //Fast Quality
        {
            QualitySettings.SetQualityLevel(1, true);
        }

        if (Input.GetKeyDown("3")) //Simple Graphics
        {
            QualitySettings.SetQualityLevel(2, true);
        }

        if (Input.GetKeyDown("4")) //Good Graphics
        {
            QualitySettings.SetQualityLevel(3, true);
        }

        if (Input.GetKeyDown("5")) //Beautiful Graphics
        {
            QualitySettings.SetQualityLevel(4, true);
        }

        if (Input.GetKeyDown("6")) //Fantastic Graphics
        {
            QualitySettings.SetQualityLevel(5, true);
        }
    }
}
