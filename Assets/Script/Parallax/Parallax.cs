using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float moveRateX;
    public float moveRateY;
    private float startPointX , startPointY;
    public bool lockY;

    private void Awake()
    {
        Cam = Camera.main.transform;
    }
    void Start()
    {
        startPointX = transform.position.x;
        startPointY = transform.position.y;
    }
    void Update()
    {
        if (lockY)
        {
            transform.position = new Vector2(startPointX + Cam.position.x * moveRateX, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(startPointX + Cam.position.x * moveRateX, startPointY + Cam.position.y * moveRateY);
        }
        
    }
}
