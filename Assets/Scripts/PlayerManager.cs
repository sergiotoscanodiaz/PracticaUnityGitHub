using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public int dashForce;
    public int health;
    public int levelTime;

    public int score;

    public Canvas canvas;

    private Rigidbody2D physics;
    private SpriteRenderer sprite;
    private new Animator animation;

    private bool vulnerable;

    private float startTime;
    private int wastedTime;
    private int contador;

    private HUDManager hud;

    private GameDataManager gameData;

    private void Start()
    {
        startTime = Time.time;

        vulnerable = true;

        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();

        hud = canvas.GetComponent<HUDManager>();

        gameData = GameObject.Find("GameData").GetComponent<GameDataManager>();

        hud.SetHealthTxt(health);
        hud.SetPowerUpTxt(GameObject.FindGameObjectsWithTag("ApplePowerUp").Length);
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        physics.velocity = new Vector2(inputX * speed, physics.velocity.y);
    }

    private void Update()
    {
        if (FloorTouching())
        {
            contador = 1;
        }
        if(Input.GetKeyDown(KeyCode.Space) && FloorTouching())
        {
            physics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (Input.GetKeyDown(KeyCode.Space) && contador == 1)
            {
                physics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (physics.velocity.x > 0) sprite.flipX = false;
        else if (physics.velocity.x < 0) sprite.flipX = true;

        animatePlayer();

        if (GameObject.FindGameObjectsWithTag("ApplePowerUp").Length == 0)
            WinLevel();

        wastedTime = (int)(Time.time - startTime);
        hud.SetTimeTxt(levelTime - wastedTime);

        if (levelTime - wastedTime < 0) GameOver();
    }

    private void WinLevel()
    {
        score = (health * 1000) + (levelTime - wastedTime);
        gameData.Score = score;
        gameData.Won = true;
        SceneManager.LoadScene("LevelEnd");
    }

    private void animatePlayer()
    {
        if (!FloorTouching()) animation.Play("playerJumping");
        else if ((physics.velocity.x > 1 || physics.velocity.x < -1) && physics.velocity.y == 0) animation.Play("playerRunning");
        else if ((physics.velocity.x < 1 || physics.velocity.x > -1) && physics.velocity.y == 0) animation.Play("playerStopped");
    }

    private bool FloorTouching()
    {
        RaycastHit2D touching = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.2f);
        return touching.collider != null;
    }

    public void GameOver()
    {
        gameData.Won = false;
        SceneManager.LoadScene("LevelEnd");
    }

    public void DamagePlayer()
    {
        if(vulnerable)
        {
            vulnerable = false;
            health -= 2;
            hud.SetHealthTxt(health);
            if (health == 0) GameOver();
            Invoke("MakeVulnerable", 1f);
            sprite.color = Color.red;
        }
    }

    private void MakeVulnerable()
    {
        vulnerable = true;
        sprite.color = Color.white;
    }

    public void PickUpPowerUp()
    {
        Invoke("UpdateHUDPowerUp", 0.2f);

        health++;
        hud.SetHealthTxt(health);

    }

    private void UpdateHUDPowerUp()
    {
        hud.SetPowerUpTxt(GameObject.FindGameObjectsWithTag("ApplePowerUp").Length);
    }

}
