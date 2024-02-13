using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoud = 35f;
    private float lowerBound = -10f;
    
    void Start()
    {
        
    }
    void Update()
    {
        if(transform.position.z > topBoud)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over !!");
            Destroy(gameObject);           
        }
    }
}
