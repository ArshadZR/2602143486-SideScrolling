using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    AudioSource jumpsound;
    public Rigidbody2D playerRigidBody;
    public float speed;
    public float input;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public CoinManager cm;
    public ParticleSystem dust;

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        jumpsound = GetComponent<AudioSource>();

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerRigidBody.velocity = Vector2.up * jumpForce;
            jumpsound.Play();
            dust.Play();
        }
    }

    void FixedUpdate()
    {
    playerRigidBody.velocity = new Vector2 (input * speed, playerRigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }

    }

    void CreateDust(){
        dust.Play();
    }

}
