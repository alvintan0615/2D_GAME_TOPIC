using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPosition : MonoBehaviour
{
    public Vector3 leftPos;
    public Vector3 rightPos;
    public float lerpSpeed;

    [SerializeField] private bool touchLeft;
    [SerializeField] private bool touchRight;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x == leftPos.x || transform.position.x < leftPos.x + 2f)
        {
            touchLeft = true;
            touchRight = false;
        }
        if (transform.position.x == rightPos.x || transform.position.x > rightPos.x - 2f)
        {
            touchLeft = false;
            touchRight = true;
        }
        if (touchLeft == true && touchRight == false)
            transform.position = Vector2.Lerp(transform.position, rightPos, lerpSpeed * Time.deltaTime);
        if (touchLeft == false && touchRight == true)
            transform.position = Vector2.Lerp(transform.position, leftPos, lerpSpeed * Time.deltaTime);
    }
}
