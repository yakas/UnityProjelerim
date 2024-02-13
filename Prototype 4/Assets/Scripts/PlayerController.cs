using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float powerupStrenght = 15.0f;
    public float speed = 15.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        playerRb = GetComponent<Rigidbody>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other) // Collider other tetikleyiciye girdiginde bu kod calisir.
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);// player powerup etiketli object ile carpistiginda powerup objectin durumunu aktif yaparak gozukmesini sagla.
            Destroy(other.gameObject);// bu playerin control class'i oldugundan playerin carptigi object yok edilir...
            StartCoroutine(PowerupCountdownRoutine());// alt routine cagiriyor.
            
        }

    }

    IEnumerator PowerupCountdownRoutine() // geri sayim metodu..
    {
        yield return new WaitForSeconds(7);// 7 saniye bekletme olusturur.
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) // hasPowerup dogru ve enemy ile player carpistiginda if deyimini dogru olarak gerceklesir
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();// carpisan enemy object'in rigidbody componentini aliyoruz ve bunu enemyRb degiskenine atiyoruz.
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;// carpisan enemy object'in vector3 posizyonu ile playerin vector3 posizyon farki aliniyor.Buradaki fark carpisma gucunu belirler.

            enemyRb.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);// player ile carpisan enemy objesine guc uygulaniyor.
        }
    }
}
