using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController controller;// PlayerController class cinsinde bir degisken olusturup adini controller yaptik.
    public float speed = 25f;
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        //controller class'a Player adinda bir GameObject'in tum componentlerini PlayerController clasindan cektik.
        //Artik PlayerControllerdaki tüm public degiskenlere ulasabiliriz.
    }

    // Update is called once per frame
    void Update()
    {
      
        if(controller.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(transform.position.x < -10 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }          
    }
}
