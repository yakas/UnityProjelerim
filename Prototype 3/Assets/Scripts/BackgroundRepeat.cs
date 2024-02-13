using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public Vector3 backgroundStartPosition;
    private float backGroundSizeHalf;
    void Start()
    {
        backgroundStartPosition = transform.position;// background resmin pozisyon bilgilerini aliyor.
        backGroundSizeHalf = GetComponent<BoxCollider>().size.x / 2; // background resmin tam yarisini aliyoruz.
    }

    
    void Update()
    {
        if (transform.position.x < backgroundStartPosition.x-backGroundSizeHalf)// background x'de tam yarisi x ekseninde kaydiginda 
        {
            transform.position= backgroundStartPosition;
        }
    }
}
