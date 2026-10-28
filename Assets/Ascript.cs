using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;  // «Ã⁄· Â–« «·„ €Ì— public · ⁄ÌÌ‰Â ›Ì Unity Editor
    public AudioManager audioManager;  // «Ã⁄· Â–« «·„ €Ì— public · ⁄ÌÌ‰Â ›Ì Unity Editor
    public bool birdIsAlive = true;

    private int pipesPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (logic == null)
        {
            logic = FindObjectOfType<LogicScript>();
        }

        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.gameOver();
        audioManager.PlayWallTouchSound();
        audioManager.PlayDeathSound();
    }

    public void OnPipePassed()
    {
        pipesPassed++;
        if (pipesPassed >= 20)
        {
            audioManager.PlayWinSound();
        }
    }
}
