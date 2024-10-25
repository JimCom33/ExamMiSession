using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBox : MonoBehaviour
{
    public float healing = 20f;
    private LineRenderer lineRenderer;
    private Player player;
    private bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayerInRange)
        {
            Debug.Log("Healing the player...");
            FindAnyObjectByType<Player>().Heal();
            UpdateLineRenderer();
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void UpdateLineRenderer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, player.transform.position);
            lineRenderer.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            isPlayerInRange = false;
            lineRenderer.enabled = false;
        }
    }
}
