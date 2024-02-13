using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 15.0f;
    
    private float xRange = 15.0f;
    public GameObject projectilePrefab;
    void Start()
    {

    }

    
    void Update()
    {
        if (transform.position.x < -xRange) // playerin x eksenindeki hareketi x <-15 dan kucukse 
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange) // playerin x eksenindeki hareketi x >15 dan buyukse 
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        horizontalInput = Input.GetAxis("Horizontal"); // bu klavyeden sol tusuna basildiginda (-1) degeri, sag tusa basildiginda (1) degeri donduruyor. -1 ..0 .. 1 arasi
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position , projectilePrefab.transform.rotation);// Instantiate() metodu bir GameObject i kopyalar(klonlar), sonrasinda playerimizin transform.position bilgilerini alir,sonrasinda ise pizzanin rotation bilgisini veriyoruz.

        }

    }
}
