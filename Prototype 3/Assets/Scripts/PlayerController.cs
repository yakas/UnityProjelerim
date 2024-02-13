using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;// bool degiskenlerin ilk degeri "false" seklindedir.
    private Animator playerAnim;
    public ParticleSystem playerCollisionParticle;// bunu ozellikle public yaptik.Cunku player objesine bu particleSystem ozelligini surukleyip birakiyoruz.
    public ParticleSystem playerDirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerSound;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
                
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) // !gameOver ...oyun gameOver olmamis ise demek.
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerDirtParticle.Stop();
            playerSound.PlayOneShot(jumpSound,0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerDirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
            Debug.Log("Game Over");
            playerCollisionParticle.Play();
            playerDirtParticle.Stop();
            playerSound.PlayOneShot(crashSound,1.5f);
        }
    }
}
