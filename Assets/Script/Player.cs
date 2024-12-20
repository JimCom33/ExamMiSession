using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float jumpForce = 5f;
    Camera playerCamera;
    public TMP_Text playerHealth;
    private const int PLAYERMAXPV = 100;
    int playerPV = PLAYERMAXPV;
    private int damagePerSecond = 1;
    public Animator gameOverAnimation;
    public TMP_Text gameOverTXT;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCamera = Camera.main;

        InvokeRepeating("LoseHealthPerSec", 1f, 1f);

        
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

        if (playerPV <= 0)
        {
            gameOverAnimation.SetTrigger("GameOver");
            gameOverTXT.color = Color.white;
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void LoseHealthPerSec()
    {
        playerPV -= damagePerSecond;

        playerPV = Mathf.Clamp(playerPV, 0, PLAYERMAXPV);
    }

    internal void CollectMelon()
    {
        playerPV = playerPV + 20;

        playerPV = Mathf.Clamp(playerPV, 0, PLAYERMAXPV);
    }

    internal void LoseHealth()
    {
        playerPV -= 20;
    }

    public void Heal()
    {
        playerPV += 20;
        playerPV = Mathf.Clamp(playerPV, 0, PLAYERMAXPV);

        Debug.Log("Getting healed");
    }
}
