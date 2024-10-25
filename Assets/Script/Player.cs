using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float jumpForce = 5f;
    Camera playerCamera;
    public TMP_Text playerHealth;
    int playerPV = 100;
    private int damagePerSecond = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCamera = Camera.main;

        InvokeRepeating("LoseHealth", 1f, 1f);

        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = "PV :" + playerPV;

        var cameraPos = playerCamera.transform.position;
        cameraPos.x = transform.position.x;
        playerCamera.transform.position = cameraPos;

        float x = Input.GetAxisRaw("Horizontal");

        var velocity = rb.velocity;
        velocity.x = 5f * x;
        rb.velocity = velocity;

        if (x != 0)
        {
            spriteRenderer.flipX = x < 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    void LoseHealth()
    {
        playerPV -= damagePerSecond;   
    }
}
