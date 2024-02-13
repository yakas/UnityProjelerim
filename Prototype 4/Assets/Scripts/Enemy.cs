using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed = 3.5f;
    private Rigidbody enemyRb;// enemy object'in rigidboy componentini almak icin enemyRb adinda ve Rigidbody class'indan enemyRb adinda bir degisken olusturduk.
    private GameObject player; // player object'in component bilgilerini almak icin GameObject class cinsinden player adinda bir degisken olusturduk.
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();// enemyRb degiskenine Rigidbody component ozelliklerini atadik.
        player = GameObject.Find("Player"); // player etiketi adinda bir GameObject aramasi yaptýk ve bunu GameObject tipinde player degiskenine atadik.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);// burada player'in vector3 bilgilerinden enemy'nin vector3 bilgisini cikardik ve bunu enemySpeed ile carptýk.Cikan sonuc kadar enemy'ye addForce'u normalize yaparak uyguladik.
        // aslinda yukardaki komut ile her frameUpdate yapildiginda player ile enemy vectorleri arasindaki fark ile enemy player'a yonelmesini sagladik.Dusman playeri takip edecek...
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
