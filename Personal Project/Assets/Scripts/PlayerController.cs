using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float x;
    private float z;
    private float speed =10f;
    private Rigidbody playerRb;
    private float xRange = 20;
    private float zRange = 20;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        ConstrainMovementPlayer();
    }
    void ConstrainMovementPlayer()
    {
        
        if (transform.position.z < -zRange) // playerin z eksenindeki hareketi z <-20 dan kucukse 
        {
            transform.position = new Vector3(transform.position.x, 0, -zRange);
        }

        if (transform.position.z > zRange) // playerin z eksenindeki hareketi z >20 dan buyukse 
        {
            transform.position = new Vector3(transform.position.x, 0, zRange);
        }
    }
    void MovementPlayer()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");



        transform.Translate(Vector3.right * x * Time.deltaTime * speed); // sag ve sol hareket ettirme islemini yapiyoruz.
        transform.Translate(Vector3.forward * z * Time.deltaTime * speed); // yukari asagi hareket ettirme islemini yapiyoruz.
        

        if (Input.GetKey(KeyCode.Space)) // bosluk tusuna basilip basilmadigini kontrol ediyoruz.
        {
            playerRb.AddForce(Vector3.up * 2f, ForceMode.Impulse); // bosluk tusuna basildiginde yukari z ekseni yonunde 2f'lik bir anlik kuvvet uygulayip playeri ziplatiyoruz.
        }
    }

    private void OnCollisionEnter(Collision collision) // bu capisma kontrolu bir rigidboy kullanan nesnelerin birbiri ile carpismasinda kullanilir.
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("player enemy ile carpisti.");
            //Destroy(gameObject);  //Destroy(gameobject) komutu ile playeri yok ediyor.Cunku PlayerController class player nesnesine ait.
            Destroy(collision.gameObject);  //Destroy(collision.gameobject) komutu ile playerin carpistigi nesneyi yok ediyor.
        }
        
    }

    private void OnTriggerEnter(Collider other) // bu metod rigidbody kullanmayan nesnelerde Collider componentinde "Is Trigger" check isareti secili oldugunda aktif olur.
    {
        if (other.gameObject)
        {
            Debug.Log("Player powerup ile carpisti..");
            Destroy(other.gameObject); //Destroy(other.gameobject) komutu ile playerin carpistigi nesneyi yok ediyor.
        }
    }




}
