using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRb;
    public float enemySpeed = 5.0F;
    private float zBoundaryDestroyLimit = -20.0f;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < zBoundaryDestroyLimit)
        {
            Destroy(gameObject);
        }
        enemyRb.AddForce(Vector3.forward * -enemySpeed);
    }
}
