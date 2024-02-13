using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 25.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, 1, 0); y ekseninde soldan saga dogru her update de 1 derece dondurur.
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed*Time.deltaTime);// sag ve sol tuslari ile kamera yonu degistirilmekte.
    }
}
